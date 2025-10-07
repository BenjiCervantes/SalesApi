namespace NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales
{
    public interface IGetAllSalesQuery
    {
        Task<List<GetAllSalesModel>> Execute();
    }
}
