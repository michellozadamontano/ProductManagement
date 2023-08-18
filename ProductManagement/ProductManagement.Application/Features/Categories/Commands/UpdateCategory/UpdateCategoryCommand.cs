using MediatR;

namespace ProductManagement.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Description, int? ParentId) : IRequest<Unit>;