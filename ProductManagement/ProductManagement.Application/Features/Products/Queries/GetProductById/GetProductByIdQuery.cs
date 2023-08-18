using MediatR;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id): IRequest<Response<ProductDto>>;
    
}
