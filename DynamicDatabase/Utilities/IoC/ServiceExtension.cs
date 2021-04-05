using Microsoft.Extensions.DependencyInjection;

namespace DynamicDatabase.Utilities.IoC
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, IResolver[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}