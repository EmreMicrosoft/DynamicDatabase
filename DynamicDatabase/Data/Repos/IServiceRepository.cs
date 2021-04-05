using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicDatabase.Data.Entities.Base;

namespace DynamicDatabase.Data.Repos
{
    public interface IServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<TEntity> Get_ById_Async(byte id);
        Task<IList<TEntity>> GetList_All_Async();


        void Add_Async(TEntity entity);
        void AddList_Async(IList<TEntity> entities);


        void Update_Async(TEntity entity);
        void UpdateList_Async(IList<TEntity> entities);


        void Delete_Async(TEntity entity);
        void DeleteList_Async(IList<TEntity> entities);
    }
}