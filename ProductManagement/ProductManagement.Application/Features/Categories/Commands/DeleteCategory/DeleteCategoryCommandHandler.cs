﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.Exceptions;
using ProductManagement.Application.Interfaces.Repositories;

namespace ProductManagement.Application.Features.Categories.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException("Category with ", request.Id);
        }
        await _categoryRepository.DeleteAsync(category);
            
        return Unit.Value;
    }
}