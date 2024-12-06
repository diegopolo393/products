using ProductosRepaso.Models;

namespace ProductosRepaso.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(string id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(string id);
    }
}
