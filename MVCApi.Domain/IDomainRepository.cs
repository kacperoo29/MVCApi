using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCApi.Domain
{
    public interface IDomainRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task Add(T entity);
    }
}