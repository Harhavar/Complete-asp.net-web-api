using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using My_Books.Data.ViewModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace My_Books.PublisherException
{
    public static class ExceptionMiddelwareExtention
    {
        public static void ConfigureBuiltinExceptionHandler( this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType= "application/json";

                    var contextlFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequestFeature = context.Features.Get<IHttpRequestFeature>();

                    if(contextlFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorVM()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextlFeature.Error.Message,
                            Path = contextRequestFeature.Path

                        }.ToString());
                    }

                });

            });
        }


        public static void ConfigureCustomExceotionHandler( this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiiddleware>();
        }
        
    }
}
