using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DynamicDatabase.Entities.Base;

namespace DynamicDatabase.Repos.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void AddList(IEnumerable<T> entities);


        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);


        void Update(T entity);
        void UpdateList(IEnumerable<T> entities);


        void Delete(T entity);
        void DeleteList(IEnumerable<T> entities);
    }
}