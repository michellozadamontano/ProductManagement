using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Wrappers;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Persistence.Contexts;

namespace ProductManagement.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    private static readonly Func<ApplicationDbContext,IAsyncEnumerable<ProductDto>> GetAllProducts = 
        EF.CompileAsyncQuery((ApplicationDbContext context) => 
            context.Products
                .Include(c => c.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId,
                })
        );

    public async Task<Pagination<ProductDto>> GetAllProductAsync(int pageNumber = 1, int pageSize = 10, string orderBy = "Id")
    {
        var productList = new List<ProductDto>();
        await foreach (var product in GetAllProducts(_dbContext))
        {
            productList.Add(product);
        }
        var totalCount = productList.Count;
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }
        else if (pageNumber > totalPages)
        {
            pageNumber = totalPages;
        }
        var skip = (pageNumber - 1) * pageSize;

        var result =  productList.OrderBy(p => p.Name).Skip(skip).Take(pageSize).ToList();
        
        return new Pagination<ProductDto>
        {
            CurrentPage = pageNumber,
            PageSize    = pageSize,
            TotalPages  = totalPages,
            TotalItems  = totalCount,
            Result      = result
        };
    }
}