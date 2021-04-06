using DynamicDatabase.Data.Entities;
using DynamicDatabase.Data.Entities.ValueRecords;
using Microsoft.EntityFrameworkCore;

namespace DynamicDatabase.Data.Access
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data\\dynamicDatabase.db");
        }
    }
}