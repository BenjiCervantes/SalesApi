using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextCloud.SalesApi.Domain.Entities;

namespace NextCloud.SalesApi.Persistence.Configuration
{
    public class SaleConfiguration
    {
        public SaleConfiguration(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);
            builder.Property(s => s.ProductQuantity).IsRequired();
            builder.Property(s => s.Total).IsRequired();
            builder.Property(s => s.SaleDate).IsRequired();
            builder.HasMany(p => p.ProductSale).WithOne(s => s.Sale).HasForeignKey(p => p.SaleId);
            //.UsingEntity(
            //    "ProductSale",
            //    r => r.HasOne(typeof(Sale)).WithMany().HasForeignKey("SaleId").HasPrincipalKey(nameof(Sale.SaleId)),
            //    l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.ProductId)),
            //    j => j.HasKey("ProductId", "SaleId")); ;
        }
    }
}
