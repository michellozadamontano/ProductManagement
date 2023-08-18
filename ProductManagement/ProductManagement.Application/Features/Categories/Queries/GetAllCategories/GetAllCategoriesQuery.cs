using System.Collections.Generic;
using MediatR;
using ProductManagement.Application.DTOs.Categories;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery():IRequest<Response<IEnumerable<CategoryDto>>>;