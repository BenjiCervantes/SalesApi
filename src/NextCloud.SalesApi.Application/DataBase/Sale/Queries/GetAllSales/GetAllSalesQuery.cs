using Microsoft.EntityFrameworkCore;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales
{
    public class GetAllSalesQuery : IGetAllSalesQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetAllSalesQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllSalesModel>> Execute()
        {
            var sales = await _dataBaseService.Sales.Include(s => s.ProductSale).ThenInclude(s=> s.Product).ToListAsync();
            return sales.ToModel();
        }
    }
}
