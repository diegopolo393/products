namespace ProductosRepaso.Dtos
{
    public record ProductDto(string Id, string Name, string? Description, decimal Price, int Stock);
}