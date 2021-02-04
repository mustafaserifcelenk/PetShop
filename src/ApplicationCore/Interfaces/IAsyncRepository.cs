using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    interface IAsyncRepository<T> where T: BaseEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> First(ISpecification<T> spec);
        Task<T> FirstOrDefault(ISpecification<T> spec);
    }
}
