namespace NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales
{
    public class GetAllSalesModel
    {
        public int SaleId { get; set; }
        public decimal Total { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime SaleDate { get; set; }
        public List<ProductInSaleModel> Products { get; set; }
    }
}
