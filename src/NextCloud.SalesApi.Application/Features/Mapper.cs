using NextCloud.SalesApi.Application.DataBase.Product.Commands.CreateProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.UpdateProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Queries.GetAllProducts;
using NextCloud.SalesApi.Application.DataBase.Product.Queries.GetProductById;
using NextCloud.SalesApi.Application.DataBase.Sale.Commands.CreateSale;
using NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales;
using NextCloud.SalesApi.Domain.Entities;

namespace NextCloud.SalesApi.Application.Features
{
    public static class Mapper
    {
        public static GetProductByIdModel ToModel(this Product product)
        {
            return new GetProductByIdModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }

        public static List<GetAllProductsModel> ToModel(this List<Product> productList)
        {
            return productList.Select(p => new GetAllProductsModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList();
        }

        public static List<GetAllSalesModel> ToModel(this List<Sale> sales)
        {
            return sales.Select(s => new GetAllSalesModel
            {
                ProductQuantity = s.ProductQuantity,
                SaleDate = s.SaleDate,
                SaleId = s.SaleId,
                Total = s.Total,
                Products = s.ProductSale.Select(ps => new ProductInSaleModel
                {
                    Name = ps.Product.Name,
                    ProductId = ps.Product.ProductId,
                    Price = ps.Product.Price,
                    Quantity = ps.ProductQuantity
                }).ToList()
            }).ToList();
        }
        public static Sale ToEntity(this CreateSaleModel model)
        {
            return new Sale
            {
                ProductQuantity = 0,
                SaleDate = DateTime.Now,
                Total = 0
            };
        }
        public static Product ToEntity(this CreateProductModel product)
        {
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }
        public static Product ToEntity(this UpdateProductModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }


    }
}
