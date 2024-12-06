using ProductosRepaso.Models;

namespace ProductosRepaso.Data
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id, string hash);
    }
}
