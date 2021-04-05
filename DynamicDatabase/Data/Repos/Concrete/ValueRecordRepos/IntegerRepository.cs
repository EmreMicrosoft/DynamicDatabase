﻿using DynamicDatabase.Data.Access;
using DynamicDatabase.Data.Entities.ValueRecords;
using DynamicDatabase.Data.Repos.Abstract.ValueRecordRepos;

namespace DynamicDatabase.Data.Repos.Concrete.ValueRecordRepos
{
    public class IntegerRepository
        : RepositoryBase<IntegerRecord, RepositoryContext>,
            IIntegerRepository
    {
    }
}