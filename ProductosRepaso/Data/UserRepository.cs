using Microsoft.EntityFrameworkCore;
using ProductosRepaso.Models;

namespace ProductosRepaso.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductDbContext _context;

        public UserRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(string id, string hash)
        {
            return await _context.Users.FirstOrDefaultAsync(x =>x.Usuario == id && x.Password == hash);
        }
    }
}
