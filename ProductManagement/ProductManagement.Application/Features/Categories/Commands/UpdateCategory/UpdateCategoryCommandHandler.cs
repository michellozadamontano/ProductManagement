using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.Exceptions;
using ProductManagement.Application.Interfaces.Repositories;

namespace ProductManagement.Application.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException("Category with ", request.Id);
        }
        category.Update(request.Name, request.Description, request.ParentId);
        await _categoryRepository.UpdateAsync(category);
        return Unit.Value;
    }
}