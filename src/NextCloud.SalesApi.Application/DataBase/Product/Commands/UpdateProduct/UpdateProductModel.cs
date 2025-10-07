namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.UpdateProduct
{
    public class UpdateProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
