using MediatR;

namespace ProductManagement.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int Quantity, int CategoryId) : IRequest<Unit>;