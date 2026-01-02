namespace Breadfast.APIs.Errors
{
    public class ApiValidationErrorResponse : ApiResponce
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();   
        public ApiValidationErrorResponse() : base(400)
        {

        }
    }
}
