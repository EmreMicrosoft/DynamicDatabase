using DynamicDatabase.Data.Access;
using DynamicDatabase.Data.Repos.Abstract;
using DynamicDatabase.Data.Repos.Abstract.ValueRecordRepos;
using DynamicDatabase.Data.Repos.Concrete;
using DynamicDatabase.Data.Repos.Concrete.ValueRecordRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicDatabase.Utilities.IoC
{
    public class Resolver : IResolver
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>),
                typeof(RepositoryBase<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<IEntityTypeRepository, EntityTypeRepository>();

            services.AddScoped<IBooleanRepository, BooleanRepository>();
            services.AddScoped<IDateTimeRepository, DateTimeRepository>();
            services.AddScoped<IDecimalRepository, DecimalRepository>();
            services.AddScoped<IIntegerRepository, IntegerRepository>();
            services.AddScoped<IStringRepository, StringRepository>();
        }
    }
}