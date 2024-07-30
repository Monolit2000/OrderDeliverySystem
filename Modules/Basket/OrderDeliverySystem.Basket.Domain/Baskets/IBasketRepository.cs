using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetByChatIdAsync(long customerChatId);

        Task<CustomerBasket?> GetByBuyerIdAsync(Guid buyerId);

        Task AddBasketAsync(CustomerBasket basket);

        //Task AddItemInBasket(CustomerBasket basket);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(CustomerBasket basket);

        Task SaveChangesAsync();
    }
}
