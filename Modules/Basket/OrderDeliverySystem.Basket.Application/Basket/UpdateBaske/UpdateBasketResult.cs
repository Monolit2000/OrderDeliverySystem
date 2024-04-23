using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketResult
    {
        public string UpdateBasketError { get; }

        public Guid BuyerId { get; }

        public Guid BasketId { get; }

        public UpdateBasketResult(string updateBasketError)
        {
            UpdateBasketError = updateBasketError;
        }

        public UpdateBasketResult(Guid basketId, Guid buyerId)
        { 
            BasketId = basketId;
            BasketId = buyerId;
        }
    }
}
