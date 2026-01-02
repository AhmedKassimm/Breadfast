using System.ComponentModel.DataAnnotations;

namespace Breadfast.APIs.Dtos.ProductsDtos
{
    public class ProductToReturnDto
    {
        [AllowedValues("int")]
        public int  Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public string? Brand { get; set; }
        public int CategoryId { get; set; }
        public string? Category { get; set; } 



    }
}
