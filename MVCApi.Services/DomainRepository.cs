using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCApi.Domain;
using MVCApi.Domain.Entites;
using MVCApi.Services.Exceptions;

namespace MVCApi.Services
{
    public class DomainRepository<TEntity> : IDomainRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly EShopContext _context;

        public DomainRepository(EShopContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return entity.Id;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize,
            Expression<Func<TEntity, bool>> filter = null)
        {
            if (pageNumber < 1)
                return new List<TEntity>();
            
            if (pageSize <  ServicesConstants.MinPageSize || pageSize > ServicesConstants.MaxPageSize)
                throw new InvalidPageSizeException(pageSize);

            return await _context.Set<TEntity>().Where(filter)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}