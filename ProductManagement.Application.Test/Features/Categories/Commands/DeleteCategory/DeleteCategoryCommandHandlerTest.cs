using MediatR;
using Moq;
using ProductManagement.Application.Features.Categories.Commands.DeleteCategory;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Test.Mocks;
using Shouldly;

namespace ProductManagement.Application.Test.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandlerTest
{
    private readonly Mock<ICategoryRepository> _categoryRepository = MockCategoryRepository.GetCategoryRepository();
    
    [Fact]
    public async Task Handle_Delete_Category()
    {
        // Arrange
        var handler = new DeleteCategoryCommandHandler(_categoryRepository.Object);
        
        // Act
        var command = new DeleteCategoryCommand(1);
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        result.ShouldBeOfType<Unit>();
        var categories = await _categoryRepository.Object.GetAllAsync();
        categories.Count().ShouldBe(2);
    }
}