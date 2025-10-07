namespace NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales
{
    public class ProductInSaleModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
