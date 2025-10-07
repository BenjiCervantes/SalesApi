using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextCloud.SalesApi.Domain.Entities;

namespace NextCloud.SalesApi.Persistence.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> builder) { 
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasMany(p => p.ProductSale).WithOne(s => s.Product).HasForeignKey(p => p.ProductId);
                //.UsingEntity(
                //    "ProductSale",
                //    r => r.HasOne(typeof(Sale)).WithMany().HasForeignKey("SaleId").HasPrincipalKey(nameof(Sale.SaleId)),
                //    l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.ProductId)),
                //    j => j.HasKey("ProductId", "SaleId")); ;
        }
    }
}
