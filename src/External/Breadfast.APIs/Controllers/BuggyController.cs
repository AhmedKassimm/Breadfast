using Breadfast.APIs.Dtos.ProductsDtos;
using Breadfast.APIs.Errors;
using Breadfast.Domain.Entities.Products;
using Breadfast.Infrastructure.Persistence.Data.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Breadfast.APIs.Controllers
{
    public class BuggyController  :BaseApiController
    {
        private readonly BreadfastDbContext _dbContext;

        public BuggyController(BreadfastDbContext dbContext)
        {
           _dbContext = dbContext;
        } 



        [HttpGet("notfound")] // GET: BaseUrl/api/buggy/notfound
        public  ActionResult NotFoundError()
        {
            var product =   _dbContext.Products.FirstOrDefault(p => p.Id == 20);

            if(product == null)
            {
                return NotFound(new ApiResponce(404));  

            }

            else
            {
                return Ok(product);
            }
        }

        [HttpGet("BadRequest")]
        public ActionResult BadRequestError()
        {
            return BadRequest(new ApiResponce(400));
        
        }

        // ValidationResponseError
        [HttpPost("BadRequest/{id}")]
        public ActionResult BadRequestError([FromRoute]TestDto mdoel)
        {
            return Ok();  
        
        }


        [HttpGet("UnAuth")]
        public ActionResult UnAuthError()
        {
            return Unauthorized(new ApiResponce(401));

        }

        [HttpGet("MethodNotAllowed")]

        public ActionResult MethodNotAllowedError()
        {
            return Ok();
        }



        [HttpGet("ServerError")]
        public ActionResult ServerError()
        {

            string test = string.Empty;
            test = null;

            return Ok(test.Length);

        }


      



    }

    public class TestDto
    {
        
        [AllowedValues(1,5,8,9,10,ErrorMessage ="Ma4 Masmo7 Ya Hamdaaaaa")]
        [Phone]
        [Required]
        [EmailAddress]
        [RegularExpression("@@")]
        [DeniedValues(50)]
        public int Id { get; set; }

        [Required(ErrorMessage = "HAMADDDDA TEST")]
        public string Name { get; set; }
    }
}
