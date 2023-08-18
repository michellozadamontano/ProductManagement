using MediatR;
using Moq;
using ProductManagement.Application.Features.Categories.Commands.UpdateCategory;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Test.Mocks;
using Shouldly;

namespace ProductManagement.Application.Test.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandlerTest
{
    private readonly Mock<ICategoryRepository> _categoryRepository = MockCategoryRepository.GetCategoryRepository();
    
    [Fact]
    public async Task Handle_Update_Category()
    {
        // Arrange
        var handler = new UpdateCategoryCommandHandler(_categoryRepository.Object);
        
        // Act
        var command = new UpdateCategoryCommand(1, "Clothes", "Some descriptions here", null);
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        result.ShouldBeOfType<Unit>();
        var categories = await _categoryRepository.Object.GetAllAsync();
        categories.Count().ShouldBe(3);
    }
}