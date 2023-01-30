using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        protected WebShopDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public AsyncRepository(IWebShopDbContext context)
        {
            _dbContext = context as WebShopDbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities)
        {
            var batchOffset = 0;
            while (batchOffset < entities.Count())
            {
                var batch = entities.Skip(batchOffset).Take(5000).ToList();
                await _dbSet.AddRangeAsync(batch);
                await _dbContext.SaveChangesAsync();

                batchOffset += batch.Count;
            }

            return entities;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync() =>
                   await _dbSet.AsNoTracking().ToListAsync();

        public virtual async Task<IList<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> filterQuery = null)
        {
            if (filterQuery != null)
            {
                return await _dbSet.Where(filterQuery).ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id) =>
            await _dbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        public async Task<bool> CheckIfExistsByIdAsync(Guid id) => !(await _dbSet.FindAsync(id) == null);

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
