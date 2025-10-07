using Microsoft.EntityFrameworkCore;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Application.DataBase.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IGetAllProductsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetAllProductsQuery(IDataBaseService dataBaseService)
        {
            this._dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllProductsModel>> Execute()
        {
            var data = await _dataBaseService.Products.ToListAsync();
            return data.ToModel();
        }
    }
}
