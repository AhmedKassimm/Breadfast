using Breadfast.Domain.Entities.Products;
using Breadfast.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces.ProductSpec
{
    public class ProductWithBrandandCategorySpec :BaseSpecification<Product>
    {

        public ProductWithBrandandCategorySpec(ProductSpecParams spec) : base(P =>

        
          (!spec.brandId.HasValue || P.BrandId == spec.brandId.Value) &&
          (!spec.categoryId.HasValue || P.CategoryId == spec.categoryId.Value))
         {

            AddIncludes();
            
            if (spec.sorting.HasValue)
            {
                switch (spec.sorting)
                {
                    case SortingOptions.PriceAsc:
                        AddOrderBy(P => P.Price);
                        break;  
                        case SortingOptions.PriceDesc:
                            AddOrderByDescending(P => P.Price);
                        break;
                     case SortingOptions.NameAsc:
                        AddOrderBy(P => P.Name);
                        break;
                    default:
                        AddOrderBy(P=> P.Name);

                        break;
                }
            }
            else
            {
                AddOrderBy(P => P.Name);
            }

            ApplyPagnation(((spec.PageIndex - 1) * spec.PageSize), spec.PageSize);
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
