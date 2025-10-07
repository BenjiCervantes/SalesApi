using System.Threading.Tasks;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public CreateProductCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<CreateProductModel> Execute(CreateProductModel model) {
            await _dataBaseService.Products.AddAsync(model.ToEntity());
            await _dataBaseService.SaveAsync();
            
            return model;
        }
    }
}
