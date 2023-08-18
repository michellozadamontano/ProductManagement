using Moq;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Test.Mocks;

public abstract class MockCategoryRepository
{
    public static Mock<ICategoryRepository> GetCategoryRepository()
    {
        var categories = new List<Category>
        {
            Category.Create(1,"Clothes", "Some descriptions here", null),
            Category.Create(2,"Men", "Some descriptions here", 1),
            Category.Create(3,"Women", "Some descriptions here", 1),
        };
        var categoryRepository = new Mock<ICategoryRepository>();

        categoryRepository.Setup(x => x.GetAllAsync())
            .ReturnsAsync(categories);
        
        categoryRepository.Setup(c => c.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => categories.FirstOrDefault(x => x.Id == id));

        categoryRepository.Setup(c => c.IsUniqueNameAsync(It.IsAny<string>()).Result).Returns((string name) =>
        {
            var index = categories.FindIndex(x => x.Name == name);
            return index == -1;
        });
        
        categoryRepository.Setup(c => c.AddAsync(It.IsAny<Category>()).Result).Returns((Category category) =>
        {
            categories.Add(category);
            return category;
        });
        
        categoryRepository.Setup(c => c.UpdateAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

        categoryRepository.Setup(c => c.DeleteAsync(It.IsAny<Category>())).Returns((Category category) =>
        {
            var index = categories.FindIndex(x => x.Id == category.Id);
            categories.RemoveAt(index);
            return Task.CompletedTask;
        });

        return categoryRepository;
    }
}