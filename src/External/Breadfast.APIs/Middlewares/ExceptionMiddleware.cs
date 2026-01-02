using Breadfast.APIs.Errors;
using System.Net;
using System.Text.Json;

namespace Breadfast.APIs.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env )
        {
           _next = next;
           _logger = logger;
           _env = env;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {

               _logger.LogError(ex, ex.Message); // Log Error In Console 

                httpContext.Response.ContentType = "application/json"; //  Set for UI Develoer --> ContentType --> application/json [text/plain]
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;  // Status Code --? 200 OK
                 
                var ResposeError = _env.IsDevelopment() ?
                    new ApiServerErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace):
                    new ApiServerErrorResponse((int)HttpStatusCode.InternalServerError, "Internal Server Error");
                await  httpContext.Response.WriteAsJsonAsync(ResposeError);

            }
        }
    }
}
