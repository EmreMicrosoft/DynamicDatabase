using DynamicDatabase.Data.Access;
using DynamicDatabase.Data.Entities;
using DynamicDatabase.Data.Repos.Abstract;

namespace DynamicDatabase.Data.Repos.Concrete
{
    public class AttributeRepository
        : RepositoryBase<Attribute, RepositoryContext>,
            IAttributeRepository
    {
    }
}