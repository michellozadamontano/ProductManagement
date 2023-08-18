﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

        Task<IEnumerable<T>> GetPagedAdvancedResponseAsync(int pageNumber, int pageSize, string orderBy, string fields);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}