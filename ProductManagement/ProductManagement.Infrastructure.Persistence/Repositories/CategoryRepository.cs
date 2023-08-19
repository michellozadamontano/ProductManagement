using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Persistence.Contexts;

namespace ProductManagement.Infrastructure.Persistence.Repositories;

public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Method to check if the category name is unique
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<bool> IsUniqueNameAsync(string name)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name && c.ParentId == null);
        return category == null;
    }

    /// <summary>
    /// Get all categories with their children
    /// </summary>
    /// <returns></returns>
    public override async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbContext.Categories
            .Include(c => c.Children)
            .Where(c => c.ParentId == null)
            .ToListAsync();
    }
    
    /// <summary>
    /// Get category by id with its children
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override async Task<Category> GetByIdAsync(int id)
    {
        return await _dbContext.Categories
            .Include(c => c.Children)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAllSubCategoriesAsync(int parentId)
    {
        return await _dbContext.Categories
            .Include(c => c.Children)
            .Where(c => c.ParentId == parentId)
            .ToListAsync();
    }
}