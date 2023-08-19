using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces.Repositories;

public interface ICategoryRepository : IGenericRepositoryAsync<Category>
{
    /// <summary>
    /// This method is used to check if the category name is unique
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<bool> IsUniqueNameAsync(string name);

    Task<IEnumerable<Category>> GetAllSubCategoriesAsync(int parentId);
}