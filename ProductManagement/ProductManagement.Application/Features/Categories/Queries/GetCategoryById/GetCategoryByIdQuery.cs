using MediatR;
using ProductManagement.Application.DTOs.Categories;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(int Id): IRequest<Response<CategoryDto>>; 