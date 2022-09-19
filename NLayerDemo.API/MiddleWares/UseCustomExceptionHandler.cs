using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLayerDemo.Core.DTOs;
using NLayerDemo.Service.Exceptions;
using System.Text.Json;

namespace NLayerDemo.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {

        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException=> 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;


                    var response = GlobalResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);


                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });










            });





        }
    }
}
