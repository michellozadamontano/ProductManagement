using FluentValidation;
using ProductManagement.Application.Features.Categories.Commands.CreateCategory;

namespace ProductManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(p => p.Price).NotEmpty().WithMessage("Price is required.");
        RuleFor(p => p.Quantity).NotEmpty().WithMessage("Quantity is required.");
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("CategoryId is required.");
    }
}