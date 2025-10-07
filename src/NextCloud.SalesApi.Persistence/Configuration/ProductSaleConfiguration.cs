using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextCloud.SalesApi.Domain.Entities;

namespace NextCloud.SalesApi.Persistence.Configuration
{
    public class ProductSaleConfiguration
    {
        public ProductSaleConfiguration(EntityTypeBuilder<ProductSale> builder) {
            builder.HasKey(ps => new { ps.ProductId, ps.SaleId });
            builder.Property(ps => ps.ProductQuantity).IsRequired();
            builder.HasOne(p => p.Product).WithMany(s => s.ProductSale).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Sale).WithMany(s => s.ProductSale).HasForeignKey(p => p.SaleId);
        } 
    }
}
