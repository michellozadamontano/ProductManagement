using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.DTOs.Categories;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;

namespace ProductManagement.Application.Features.Categories.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetByIdAsync(request.Id);

        return categories == null
            ? throw new KeyNotFoundException($"Category {request.Id} not found")
            : new Response<CategoryDto>((CategoryDto)categories);
    }
}