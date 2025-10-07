namespace NextCloud.SalesApi.Domain.Entities
{
    public class ProductSale
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public int ProductQuantity { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
