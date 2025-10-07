using NextCloud.SalesApi.Domain.Models;

namespace NextCloud.SalesApi.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, object? data = null, string? message = null)
        {
            return new BaseResponseModel
            {
                Success = statusCode >= 200 && statusCode < 300,
                StatusCode = statusCode,
                Data = data,
                Message = message
            };
        }
    }
}
