using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.DTOs.Products;

public record ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public int CategoryId { get; init; }
    
    //use explicit operator to map from Product to ProductDto.
    public static explicit operator ProductDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId
        };
    }
}