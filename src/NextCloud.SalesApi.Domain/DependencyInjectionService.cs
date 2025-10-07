using Microsoft.Extensions.DependencyInjection;

namespace NextCloud.SalesApi.Domain
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
