using Microsoft.Extensions.DependencyInjection;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.CreateProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.DeleteProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.UpdateProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Queries.GetAllProducts;
using NextCloud.SalesApi.Application.DataBase.Product.Queries.GetProductById;
using NextCloud.SalesApi.Application.DataBase.Sale.Commands.CreateSale;
using NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales;

namespace NextCloud.SalesApi.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, UpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
            services.AddTransient<IGetAllProductsQuery, GetAllProductsQuery>();
            services.AddTransient<IGetProductByIdQuery, GetProductByIdQuery>();

            services.AddTransient<ICreateSaleCommand, CreateSaleCommand>();
            services.AddTransient<IGetAllSalesQuery, GetAllSalesQuery>();
            return services;
        }
    }
}
