using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Domain.Baskets;
using OrderDeliverySystem.Basket.Infrastructure.Persistence;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;
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

        public async Task AddBasketAsync(CustomerBasket basket)
        {
            await _basketContext.Baskets.AddAsync(basket);

            //await _basketContext.SaveChangesAsync();

            //var test = await GetBasketAsync(basket.BuyerChatId);
            //await Console.Out.WriteLineAsync($"REPO - {test.BuyerChatId}");
        }

        public Task<bool> DeleteBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerBasket> GetBasketAsync(long customerChatId)
        {
            var customerBasket = await _basketContext.Baskets
                .FirstOrDefaultAsync(b => b.BuyerChatId == customerChatId);

            return customerBasket;
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _basketContext.SaveChangesAsync();
        }
    }
}
