namespace NextCloud.SalesApi.Application.DataBase.Product.Queries.GetProductById
{
    public interface IGetProductByIdQuery
    {
        Task<GetProductByIdModel> Execute(int productId);
    }
}
