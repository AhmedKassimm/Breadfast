
namespace Breadfast.APIs.Errors
{
    public class ApiResponce
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponce(int statusCode, string? message =null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);

        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {



            Message = statusCode switch
            {
             
                400 => "A Bad Request ,You Have Made",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Resource was Not Found",
                405 => "Method Not Allowed",
                500 => "Internal Server Error",
                _ => "An unexpected error occurred."


            };
            return Message;
        }
    }
}
