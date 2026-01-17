using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Entities.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();

        public CustomerBasket(string id)
        {
            Id = id;
        }
    }
}
