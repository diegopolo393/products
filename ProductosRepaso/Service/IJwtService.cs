using ProductosRepaso.Dtos;

namespace ProductosRepaso.Service
{
    public interface IJwtService
    {
        Task<string> Login(UserDto userDto);
    }
}
