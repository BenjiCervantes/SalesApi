namespace NextCloud.SalesApi.Domain.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public decimal Total { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime SaleDate { get; set; }
        public List<ProductSale> ProductSale { get; set; }
    }
}
