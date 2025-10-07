namespace NextCloud.SalesApi.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<ProductSale> ProductSale { get; set; }
    }
}
