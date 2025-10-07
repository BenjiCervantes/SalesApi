using Microsoft.EntityFrameworkCore;
using NextCloud.SalesApi.Domain.Entities;

namespace NextCloud.SalesApi.Application.DataBase
{
    public interface IDataBaseService
    {
        public DbSet<Domain.Entities.Product> Products { get; set; }
        public DbSet<Domain.Entities.Sale> Sales { get; set; }
        public DbSet<ProductSale> ProductSale { get; set; }

        Task<bool> SaveAsync();
    }
}
