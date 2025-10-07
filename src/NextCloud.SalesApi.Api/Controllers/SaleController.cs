using Microsoft.AspNetCore.Mvc;
using NextCloud.SalesApi.Application.DataBase.Sale.Commands.CreateSale;
using NextCloud.SalesApi.Application.DataBase.Sale.Queries.GetAllSales;
using NextCloud.SalesApi.Application.Exceptions;
using NextCloud.SalesApi.Application.Features;

namespace NextCloud.SalesApi.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SaleController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateSaleModel model,
            [FromServices] ICreateSaleCommand command)
        {
            var result = await command.Execute(model);
            if (!result)
            {
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status404NotFound, null, "El producto no se encontró"));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, result));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllSalesQuery query)
        {
            var result = await query.Execute();
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, result));
        }
    }
}
