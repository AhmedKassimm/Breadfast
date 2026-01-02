using Breadfast.Domain.Entities.Products;
using Breadfast.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces.ProductSpec
{
    public class ProductWithBrandandCategorySpec :BaseSpecification<Product>
    {
       
        public ProductWithBrandandCategorySpec(SortingOptions sorting)
        {

            AddIncludes();

        }

        public ProductWithBrandandCategorySpec(int id):base(P => P.Id == id)
        {
           AddIncludes();
        }

        private void AddIncludes()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
