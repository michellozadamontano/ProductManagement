using Moq;
using ProductManagement.Application.Features.Categories.Commands.CreateCategory;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Test.Mocks;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;
using Shouldly;

namespace ProductManagement.Application.Test.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandlerTest
{
    private readonly Mock<ICategoryRepository> _categoryRepository = MockCategoryRepository.GetCategoryRepository();

    [Fact]
    public async Task Handle_Create_Category()
    {
        // Arrange
        var handler = new CreateCategoryCommandHandler(_categoryRepository.Object);
        
        // Act
        var command = new CreateCategoryCommand("Toys", "Children toys",null);
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        result.ShouldBeOfType<Response<Category>>();
        var categories = await _categoryRepository.Object.GetAllAsync();
        categories.Count().ShouldBe(4);
    }
}