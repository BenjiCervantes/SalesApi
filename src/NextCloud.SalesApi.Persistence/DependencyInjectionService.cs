using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NextCloud.SalesApi.Application.DataBase;
using NextCloud.SalesApi.Persistence.DataBase;

namespace NextCloud.SalesApi.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(configuration.GetConnectionString("InventoryDB")));
            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}
