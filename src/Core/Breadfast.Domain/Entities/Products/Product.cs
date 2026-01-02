using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } =default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public virtual ProductBrand? Brand { get; set; }

        public int CategoryId { get; set; }
        public virtual ProductCategory? Category { get; set; }

    }
}
