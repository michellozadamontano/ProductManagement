using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.Exceptions;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// </summary>
    /// <param name="categoryRepository"></param>
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    /// <summary>
    /// Handle the request to create a new category
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public async Task<Response<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException("Incorrect data", validationResult);
        }
        var category = (Category)request;
        var isUnique = await _categoryRepository.IsUniqueNameAsync(category.Name);
        if (!isUnique)
        {
            throw new ValidationException($"Category with name {category.Name} already exists");
        }
        var createdCategory = await _categoryRepository.AddAsync(category);
        return new Response<Category>(createdCategory);
    }
}