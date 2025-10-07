namespace NextCloud.SalesApi.Application.DataBase.Product.Queries.GetAllProducts
{
    public interface IGetAllProductsQuery
    {
        Task<List<GetAllProductsModel>> Execute();
    }
}
