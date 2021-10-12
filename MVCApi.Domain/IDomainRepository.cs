using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVCApi.Domain.Entites;

namespace MVCApi.Domain
{
    public interface IDomainRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task Add(TEntity entity);
    }
}