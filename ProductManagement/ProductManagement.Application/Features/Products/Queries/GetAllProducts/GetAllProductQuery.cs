using MediatR;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductQuery(int PageNumber, int PageSize): IRequest<Response<Pagination<ProductDto>>>;