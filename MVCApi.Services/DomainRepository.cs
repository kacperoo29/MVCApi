using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

namespace MVCApi.Services
{
    public class DomainRepository<TEntity> : IDomainRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Task<Guid> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}