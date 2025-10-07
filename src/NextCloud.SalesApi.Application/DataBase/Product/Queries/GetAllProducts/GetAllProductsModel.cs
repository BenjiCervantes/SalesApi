namespace NextCloud.SalesApi.Application.DataBase.Product.Queries.GetAllProducts
{
    public class GetAllProductsModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
