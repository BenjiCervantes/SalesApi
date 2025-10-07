using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public UpdateProductCommand(IDataBaseService dataBaseService)
        {
            this._dataBaseService = dataBaseService;
        }

        public async Task<UpdateProductModel> Execute(UpdateProductModel model)
        {
            _dataBaseService.Products.Update(model.ToEntity());
            await _dataBaseService.SaveAsync();
            return model;
        }

    }
}
