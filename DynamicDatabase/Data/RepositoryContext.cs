using System;
using DynamicDatabase.Entities.ValueRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DynamicDatabase.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Attribute> Attributes { get; set; }

        public DbSet<BooleanRecord> BooleanRecords { get; set; }
        public DbSet<DateTimeRecord> DateTimeRecords { get; set; }
        public DbSet<DecimalRecord> DecimalRecords { get; set; }
        public DbSet<IntegerRecord> IntegerRecords { get; set; }
        public DbSet<StringRecord> StringRecords { get; set; }
    }
}