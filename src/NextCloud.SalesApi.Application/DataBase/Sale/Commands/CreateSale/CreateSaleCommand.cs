using Microsoft.EntityFrameworkCore;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Application.DataBase.Sale.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IDataBaseService _dataBaseService;
        public CreateSaleCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(CreateSaleModel model)
        {
            IEnumerable<int> productIdList = model.Products.Select(m => m.ProductId);
            List<Domain.Entities.Product> products = await _dataBaseService.Products.Where(p => productIdList.Contains(p.ProductId)).ToListAsync();
            if(productIdList.Count() != products.Count)
            {
                throw new Exception("Alguno de los productos que se ingresó no se encuentra registrado.");
            }
            if(products.Any(p => p.Quantity < model.Products.First( m => m.ProductId == p.ProductId).Quantity))
            {
                throw new Exception("Alguno de los productos que se ingresó no cuenta con stock suficiente.");
            }
            Domain.Entities.Sale entity = model.ToEntity();
            entity.ProductSale = model.Products.Select(p => new Domain.Entities.ProductSale { ProductId = p.ProductId, ProductQuantity = p.Quantity }).ToList();
            entity.ProductQuantity = model.Products.Sum(p => p.Quantity);
            entity.Total = products.Sum(p => p.Price * model.Products.First(m => m.ProductId == p.ProductId).Quantity);
            await _dataBaseService.Sales.AddAsync(entity);
            products.ForEach(product => product.Quantity -= model.Products.First(m => m.ProductId == product.ProductId).Quantity);
            _dataBaseService.Products.UpdateRange(products);
            return await _dataBaseService.SaveAsync();
        }
    }
}
