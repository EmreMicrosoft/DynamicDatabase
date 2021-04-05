using Microsoft.Extensions.DependencyInjection;

namespace DynamicDatabase.Utilities.IoC
{
    public interface IResolver
    {
        void Load(IServiceCollection services);
    }
}