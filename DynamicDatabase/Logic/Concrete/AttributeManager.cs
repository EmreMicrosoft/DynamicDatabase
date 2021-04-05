using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicDatabase.Data.Entities;
using DynamicDatabase.Data.Repos.Abstract;
using DynamicDatabase.Logic.Abstract;

namespace DynamicDatabase.Logic.Concrete
{
    public class AttributeManager : IAttributeService
    {
        private readonly IAttributeRepository _repos;

        public AttributeManager(IAttributeRepository repos)
        {
            _repos = repos;
        }

        public Task<Attribute> Get_ById_Async(byte id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Attribute>> GetList_All_Async()
        {
            throw new System.NotImplementedException();
        }

        public void Add_Async(Attribute entity)
        {
            throw new System.NotImplementedException();
        }

        public void AddList_Async(IList<Attribute> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Update_Async(Attribute entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateList_Async(IList<Attribute> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete_Async(Attribute entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteList_Async(IList<Attribute> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}