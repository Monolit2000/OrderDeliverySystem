using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketByChatIdAsync(long customerChatId);

        Task<CustomerBasket> GetBasketByBuyerIdAsync(Guid buyerId);

        Task AddBasketAsync(CustomerBasket basket);

        //Task AddItemInBasket(CustomerBasket basket);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(CustomerBasket basket);

        Task SaveChangesAsync();
    }
}
