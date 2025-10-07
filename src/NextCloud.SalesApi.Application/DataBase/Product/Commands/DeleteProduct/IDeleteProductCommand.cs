namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.DeleteProduct
{
    public interface IDeleteProductCommand
    {
        Task<bool> Execute(int productId);
    }
}
