namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.CreateProduct
{
    public interface ICreateProductCommand
    {
        Task<CreateProductModel> Execute(CreateProductModel model);
    }
}
