namespace ProductosRepaso.Models
{
    public class Product(string? id, string name, string? description, decimal price, int stock)
    {
        public string Id { get; set; } = id ?? Guid.NewGuid().ToString();
        public string Name { get; set; } = name;
        public string? Description { get; set; } = description;
        public decimal Price { get; set; } = price;
        public int Stock { get; set; } = stock;
    }
}