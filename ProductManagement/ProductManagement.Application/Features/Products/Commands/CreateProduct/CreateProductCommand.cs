using MediatR;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name, string Description, decimal Price, int Quantity, int CategoryId) : IRequest<Response<Product>>
{
    public static explicit operator Product(CreateProductCommand command)
    {
        return Product.Create(null, command.Name, command.Description, command.Price, command.Quantity, command.CategoryId);
    }
}