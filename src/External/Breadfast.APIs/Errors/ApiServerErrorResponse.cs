namespace Breadfast.APIs.Errors
{
    public class ApiServerErrorResponse :ApiResponce
    {
        public string? Detials { get; set; }

        public ApiServerErrorResponse(int statusCode ,string? message = null , string? detials = null):base(statusCode,message)
        {

            Detials = detials;  

        }
    }
}
