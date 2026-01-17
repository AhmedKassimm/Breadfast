using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breadfast.Domain.Entities.Basket;
using Breadfast.Domain.Interfaces;
using StackExchange.Redis;

namespace Breadfast.Infrastructure.Memory
{
    internal class BasketRepositry : IBasketRepositry 
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public BasketRepositry(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }
        public Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }
        public Task<CustomerBasket> AddOrUpdateBasketAsync(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }

    }
}
