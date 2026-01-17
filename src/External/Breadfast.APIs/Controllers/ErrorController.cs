using Breadfast.APIs.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Breadfast.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {

        public ActionResult Error(int code)
        {

            var response = code switch
            {
                400 => new ApiResponce(400),
                401 => new ApiResponce(401),
                403 => new ApiResponce(403),
                404 => new ApiResponce(404),
                405 => new ApiResponce(405),
                500 => new ApiResponce(500),
                _ => new ApiResponce(code, "An error occurred")
            };
            return StatusCode(code, response);  
        }
    }
}
