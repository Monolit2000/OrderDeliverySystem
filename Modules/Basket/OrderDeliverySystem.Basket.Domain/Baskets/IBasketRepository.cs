using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(long customerChatId);

        Task AddBasketAsync(CustomerBasket basket);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string id);
    }
}
