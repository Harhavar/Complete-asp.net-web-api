using Microsoft.AspNetCore.Http;
using My_Books.Data.ViewModel;
using System;
using System.Net;

namespace My_Books.PublisherException
{
    public class CustomExceptionMiiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public  async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync( httpContext , ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext , Exception ex)
        {
            httpContext.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var responce = new ErrorVM()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message,
                Path = ex.Message,
            };
            return httpContext.Response.WriteAsync(responce.ToString());
        }
    }
}
