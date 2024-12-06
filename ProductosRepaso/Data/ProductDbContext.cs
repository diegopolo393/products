using Microsoft.EntityFrameworkCore;
using ProductosRepaso.Models;

namespace ProductosRepaso.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}