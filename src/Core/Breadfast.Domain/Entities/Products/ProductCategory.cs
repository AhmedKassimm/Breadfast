using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Entities.Products
{
    public class ProductCategory:BaseEntity
    {
        public string Name { get; set; } = default!;
     //   public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }

}
