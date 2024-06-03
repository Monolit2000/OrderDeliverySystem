using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketResult
    {
        public Guid BuyerId { get; }

        public Guid BasketId { get; }

        public UpdateBasketResult(Guid basketId, Guid buyerId)
        { 
            BasketId = basketId;
            BuyerId = buyerId;
        }
    }
}
