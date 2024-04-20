using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Basket
{
    public class CustomerBasket : Entity, IAggregateRoot
    {
        public Guid BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = [];

        public CustomerBasket() { }

        public CustomerBasket(Guid customerId)
        {
            BuyerId = customerId;
        }
    }
}
