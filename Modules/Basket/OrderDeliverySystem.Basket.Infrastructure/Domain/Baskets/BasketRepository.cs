using OrderDeliverySystem.Basket.Domain.Baskets;
using OrderDeliverySystem.Basket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure.Domain.Baskets
{
    public class BasketRepository : IBasketRepository
    {
        private BasketContext _basketContext;

        public BasketRepository(BasketContext basketContext )
        {
            _basketContext = basketContext;
        }

        public Task<bool> DeleteBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> GetBasketAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
