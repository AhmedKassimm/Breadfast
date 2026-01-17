using Breadfast.Domain.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces
{
    public interface IBasketRepositry
    {
       Task<CustomerBasket> AddOrUpdateBasketAsync(CustomerBasket basket);
       Task<CustomerBasket> GetBasketAsync(string basketId);    
       Task<bool> DeleteBasketAsync(string basketId);

    }
}
