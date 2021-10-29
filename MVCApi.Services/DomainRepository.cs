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
        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public DomainRepository(EShopContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> Delete(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null 
                ? await DbSet.Where(filter).ToListAsync() 
                : await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize,
            Expression<Func<TEntity, bool>> filter = null)
        {
            if (pageNumber < 1)
                return new List<TEntity>();

            if (pageSize < ServicesConstants.MinPageSize || pageSize > ServicesConstants.MaxPageSize)
                throw new InvalidPageSizeException(pageSize);

            return filter != null
                ? await DbSet.Where(filter).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()
                : await DbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}