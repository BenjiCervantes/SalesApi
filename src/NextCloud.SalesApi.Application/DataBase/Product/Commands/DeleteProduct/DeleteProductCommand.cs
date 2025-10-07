using Microsoft.EntityFrameworkCore;

namespace NextCloud.SalesApi.Application.DataBase.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteProductCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int productId)
        {
            var product = await _dataBaseService.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product == null)
            {
                return false;
            }
            _dataBaseService.Products.Remove(product);
            return await _dataBaseService.SaveAsync();

        }
    }
}
