using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Breadfast.Domain.Entities.Products
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; } = default!;
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  //Not Mapped from C# Object to Json when propety = NULL
        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
