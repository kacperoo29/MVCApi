using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCApi.Application;
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

        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public async Task<Guid> AddAsync(TEntity entity)
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

        public async Task<Guid> EditAsync(TEntity entity)
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

        public async Task<IPaginatedList<TEntity>> GetPaginatedAsync(int pageNumber, int pageSize,
            Expression<Func<TEntity, bool>> filter = null)
        {
            if (pageNumber < 1)
                return default;

            if (pageSize < ServicesConstants.MinPageSize || pageSize > ServicesConstants.MaxPageSize)
                throw new InvalidPageSizeException(pageSize);

            return filter != null
                ? await PaginationHelpers<TEntity>.CreateAsync(DbSet, pageNumber, pageSize, filter)
                : await PaginationHelpers<TEntity>.CreateAsync(DbSet, pageNumber, pageSize);
        }

        public async Task<IPaginatedList<TEntity>> SqlQueryPaginated(string query, int pageNumber, int pageSize)
        {
            var result = await DbSet.FromSqlRaw(query).ToListAsync();
            var count = await DbSet.CountAsync();

            return new PaginatedList<TEntity>(result, count, pageNumber, pageSize);
        }
    }
}