using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Access
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new RepositoryContext();
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            await using var context = new RepositoryContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }


        public async void AddAsync(TEntity entity)
        {
            await using var context = new RepositoryContext();
            await Task.Run(() => context.AddAsync(entity));
            await context.SaveChangesAsync();
        }

        public async void UpdateAsync(TEntity entity)
        {
            await using var context = new RepositoryContext();
            await Task.Run(() => context.Update(entity));
            await context.SaveChangesAsync();
        }

        public async void DeleteAsync(TEntity entity)
        {
            await using var context = new RepositoryContext();
            await Task.Run(() => context.Remove(entity));
            await context.SaveChangesAsync();
        }
    }
}