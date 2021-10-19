using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCApi.Domain;
using MVCApi.Domain.Entites;

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

        public async Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}