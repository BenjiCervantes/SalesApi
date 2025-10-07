namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.UpdateProduct
{
    public interface IUpdateProductCommand
    {
        Task<UpdateProductModel> Execute(UpdateProductModel model);
    }
}
