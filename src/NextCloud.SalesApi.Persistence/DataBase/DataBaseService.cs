using Microsoft.EntityFrameworkCore;
using NextCloud.SalesApi.Application.DataBase;
using NextCloud.SalesApi.Domain.Entities;
using NextCloud.SalesApi.Persistence.Configuration;

namespace NextCloud.SalesApi.Persistence.DataBase
{
    public class DataBaseService(DbContextOptions options) : DbContext(options), IDataBaseService
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ProductSale> ProductSale { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new SaleConfiguration(modelBuilder.Entity<Sale>());
            new ProductSaleConfiguration(modelBuilder.Entity<ProductSale>());
        }
    }
}
