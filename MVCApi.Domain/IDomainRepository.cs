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

        Task<IPaginatedList<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize,
            Expression<Func<TEntity, bool>> filter = null);

        Task<IPaginatedList<TEntity>> SqlQueryPaginated(string query, int pageNumber, int pageSize);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<Guid> AddAsync(TEntity entity);
        Task<Guid> EditAsync(TEntity entity);
        Task<Guid> Delete(TEntity entity);
    }
}