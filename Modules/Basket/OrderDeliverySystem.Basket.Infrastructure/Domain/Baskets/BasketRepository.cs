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

            await _basketContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteBasketAsync(CustomerBasket basket)
        {
            _basketContext.Remove(basket);

            return true;
        }

        public async Task<CustomerBasket> GetBasketAsync(long customerChatId)
        {


            var customerBasket = await _basketContext.Baskets.FirstOrDefaultAsync(b => b.BuyerChatId == customerChatId); ;

            if (customerBasket != null)
            {
                await _basketContext.Entry(customerBasket)
                    .Collection(i => i.Items).LoadAsync();
            }

            return customerBasket;





            //var customerBasket = await _basketContext.Baskets
            //    .Include(b => b.Items)
            //    .FirstOrDefaultAsync(b => b.BuyerChatId == customerChatId);

            //return customerBasket;
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
