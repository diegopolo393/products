using Microsoft.AspNetCore.Mvc;
using ProductosRepaso.Data;
using ProductosRepaso.Dtos;
using ProductosRepaso.Service;
using System.Security.Cryptography;
using System.Text;

namespace ProductosRepaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _token;
        private readonly IUserRepository _repository;

        public AuthController(IJwtService token, IUserRepository repository)
        {
            _token = token;
            _repository = repository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> PostLogin(UserDto login)
        {
            try
            {
                var hash = HashPasswordToBase64(login.usuario);

                var user = await _repository.GetByIdAsync(login.usuario, hash);

                if (user == null)
                    return NotFound($"No se encontro el {nameof(User)}");

                string jwt = await _token.Login(login);

                var response = new 
                {
                    token = jwt,
                    usuario = login.usuario
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(403, ex.Message);
            }
        }

        private string HashPasswordToBase64(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
