using Microsoft.IdentityModel.Tokens;
using ProductosRepaso.Dtos;
using ProductosRepaso.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductosRepaso.Service
{
    public class JwtService :IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> Login(UserDto userDto)
        {
            var user = new User(userDto.usuario, userDto.clave);

            string token = CrearToken(user);
            return Task.FromResult(token);
        }

        private string CrearToken(User usuario)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, usuario.Usuario),
                new(ClaimTypes.Name, usuario.Usuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("TokenSecurityKey").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokeDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokeDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
