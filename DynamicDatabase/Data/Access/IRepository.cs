using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Access
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void AddAsync(T entity);
        void AddListAsync(IList<T> entities);


        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null);


        void UpdateAsync(T entity);
        void UpdateListAsync(IList<T> entities);


        void DeleteAsync(T entity);
        void DeleteListAsync(IList<T> entities);
    }
}