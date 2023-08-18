using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.DTOs.Categories;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Categories.Queries.GetAllCategories;

public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Response<IEnumerable<CategoryDto>>>
{
    private readonly ICategoryRepository _categoryRepository;
    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Response<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        // map to category dto
        var categoriesDto = categories.Select(c => (CategoryDto)c);

        return new Response<IEnumerable<CategoryDto>>(categoriesDto);
    }
}