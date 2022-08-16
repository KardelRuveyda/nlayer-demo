using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLayerDemo.Core.DTOs;
using NLayerDemo.Service.Exceptions;
using System.Text.Json;

namespace NLayerDemo.API.MiddleWares
{
    public static class UserCustomExceptionHandler
    {
        public static void UserCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    //// bakılacak. pattern desteklemiyor 3.2 de
                    //var statusCode = exceptionFeature.Error switch
                    //{
                    //    ClientSideException => 400,
                    //    _ => 500
                    //};
                    context.Response.StatusCode = 400;
                    var response = GlobalResponseDto<NoContentDto>.Fail(context.Response.StatusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
