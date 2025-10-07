using Microsoft.EntityFrameworkCore;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Application.DataBase.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IGetProductByIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetProductByIdQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<GetProductByIdModel> Execute(int productId)
        {
            var data = await _dataBaseService.Products.FirstOrDefaultAsync(p=> p.ProductId == productId);
            return data?.ToModel();
        }
    }
}
