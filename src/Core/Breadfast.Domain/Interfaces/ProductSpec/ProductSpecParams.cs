using Breadfast.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces.ProductSpec
{
    public class ProductSpecParams
    {
       
        public SortingOptions? sorting { get; set; }
        public int? brandId { get; set; }
        public int? categoryId { get; set; }


        private const int MaxPageSize = 10;
        private int pageSize = 6;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? pageSize = MaxPageSize : pageSize = value ; }
        }

        
        public int PageIndex { get; set; } = 1; 
    }
}
