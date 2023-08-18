using FluentValidation;

namespace ProductManagement.Application.Features.Categories.Commands.CreateCategory;

internal class CreateCategoryValidator: AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");            
    }
}  