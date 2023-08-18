using System.Threading.Tasks;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces.Repositories;

public interface IProductRepository : IGenericRepositoryAsync<Product>
{
    Task<Pagination<ProductDto>> GetAllProductAsync(int pageNumber = 1, int pageSize = 10, string orderBy = "Id");
}