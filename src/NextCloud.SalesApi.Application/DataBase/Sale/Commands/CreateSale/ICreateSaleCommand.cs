namespace NextCloud.SalesApi.Application.DataBase.Sale.Commands.CreateSale
{
    public interface ICreateSaleCommand
    {
        Task<bool> Execute(CreateSaleModel model);
    }
}
