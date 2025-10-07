using Microsoft.AspNetCore.Mvc;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.CreateProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.DeleteProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Commands.UpdateProduct;
using NextCloud.SalesApi.Application.DataBase.Product.Queries.GetAllProducts;
using NextCloud.SalesApi.Application.DataBase.Product.Queries.GetProductById;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductModel model,
            [FromServices] ICreateProductCommand command)
        {
            var result = await command.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, result));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateProductModel model,
            [FromServices] IUpdateProductCommand command)
        {
            var result = await command.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, result));
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> Delete(
            int productId,
            [FromServices] IDeleteProductCommand command)
        {
            var result = await command.Execute(productId);
            if (!result)
            {
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El producto no se encontró"));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, result));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllProductsQuery query)
        {
            var result = await query.Execute();
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, result));
        }

        [HttpGet("get-by-id/{productId}")]
        public async Task<IActionResult> GetById(
            int productId,
            [FromServices] IGetProductByIdQuery query)
        {
            var result = await query.Execute(productId);
            if(result == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El producto no se encontró"));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, result));
        }
    }
}
