using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MVCApi.Domain.Entites;

namespace MVCApi.Domain
{
    public interface IDomainRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize,
            Expression<Func<TEntity, bool>> filter = null);
        Task<Guid> Add(TEntity entity);
    }
}