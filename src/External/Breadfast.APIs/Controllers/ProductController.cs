using AutoMapper;
using Breadfast.APIs.Dtos.ProductsDtos;
using Breadfast.APIs.Errors;
using Breadfast.Domain.Entities.Products;
using Breadfast.Domain.Enums;
using Breadfast.Domain.Interfaces;
using Breadfast.Domain.Interfaces.ProductSpec;
using Breadfast.Infrastructure.Persistence.Data.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Breadfast.APIs.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepositry<Product> _productRepo;
        private readonly IGenericRepositry<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepositry<ProductCategory> _productCategoriesRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepositry<Product> productRepo,
            IGenericRepositry<ProductBrand> productBrandsRepo,
            IGenericRepositry<ProductCategory> productCategoriesRepo,
            
            IConfiguration configuration,
            IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _productRepo = productRepo;
           _productBrandsRepo = productBrandsRepo;
           _productCategoriesRepo = productCategoriesRepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAllProducts(SortingOptions sortingOption)
        {
            //  var spec = new BaseSpecification<Product>()
            //  {
            //      Includes  = { 
            //          P => P.Brand,   
            //          P => P.Category 
            //      }
            //  };

            var baseUrl = _configuration["baseUrl"];
            var spec  = new ProductWithBrandandCategorySpec(sortingOption);  
            var products = await _productRepo.GetAllWithSpec(spec);
           var  productDto = _mapper.Map<List<ProductToReturnDto>>(products);
           // // Manual Mapping
           // var productDto = products.Select(p => new ProductToReturnDto
           // {
           //     Id = p.Id,
           //     Name = p.Name,
           //     Description = p.Description,
           //     PictureUrl = $"{baseUrl}/{p.PictureUrl}",
           //     Price = p.Price,
           //     BrandId = p.BrandId,
           //     Brand = p.Brand?.Name ?? "No Brand Name",
           //     CategoryId = p.CategoryId,
           //     Category = p.Category?.Name ?? "No Category Name"
           //
           // });
            return Ok(productDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {

            var baseUrl = $"https://localhost:7097/{_configuration["baseUrl"]}";
            var spec = new ProductWithBrandandCategorySpec(id);
            var product = await _productRepo.GetWithSpec(spec);

            if (product is not null)
                return Ok(new ProductToReturnDto
                {
                    // Manual Mapping
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    PictureUrl = $"{baseUrl}/{product.PictureUrl}",
                    Price = product.Price,
                    BrandId = product.BrandId,
                    Brand = product.Brand?.Name ?? "No Brand Name",
                    CategoryId = product.CategoryId,
                    Category = product.Category?.Name ?? "No Category Name"
                });

            else
            {
                return NotFound (new ApiResponce(404));    
            }
        }




        [HttpGet("brands")] // GET : BaseUrl/api/products/brands
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await _productBrandsRepo.GetAll();
            return Ok(brands);  
        }
     


        [HttpGet("categories")] // GET : BaseUrl/api/products/categories
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            var categories = await _productCategoriesRepo.GetAll();
            return Ok(categories);  
        }

    }
}
