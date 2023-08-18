using MediatR;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, string Description, int? ParentId) : IRequest<Response<Category>>
{
    // use explicit operator to map from CreateCategoryCommand to Category
    public static explicit operator Category(CreateCategoryCommand command)
    {
        return Category.Create(null, command.Name, command.Description, command.ParentId);
    }
}