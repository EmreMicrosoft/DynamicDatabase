using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Repos.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        // ADD
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            context.Add(entity);
            context.SaveChanges();
        }

        // ADD LIST
        public void AddList(IList<TEntity> entities)
        {
            using var context = new TContext();
            context.AddRange(entities);
            context.SaveChanges();
        }



        // GET
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        // GET LIST
        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }



        // UPDATE
        public void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Update(entity);
            context.SaveChanges();
        }

        // UPDATE LIST
        public void UpdateList(IList<TEntity> entities)
        {
            using var context = new TContext();
            context.UpdateRange(entities);
            context.SaveChanges();
        }



        // DELETE
        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            context.Remove(entity);
            context.SaveChanges();
        }

        // DELETE LIST
        public void DeleteList(IList<TEntity> entities)
        {
            using var context = new TContext();
            context.RemoveRange(entities);
            context.SaveChanges();
        }
    }
}