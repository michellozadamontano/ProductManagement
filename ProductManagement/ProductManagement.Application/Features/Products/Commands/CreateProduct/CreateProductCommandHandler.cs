using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Application.Exceptions;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Response<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // validate the request
        var validator = new CreateProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException("Incorrect data", validationResult);
        }

        // map the request to a product
        var product = (Product)request;
        await _productRepository.AddAsync(product);
        
        return new Response<Product>(product);
    }
}