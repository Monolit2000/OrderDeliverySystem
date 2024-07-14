using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets.Event
{
    public class BasketItemUnitPriceUpdatedDomainEvent : DomainEventBase
    {
        public Guid BasketItemId { get; }
        public decimal NewUnitPrice { get; }

        public BasketItemUnitPriceUpdatedDomainEvent(Guid basketItemId, decimal newUnitPrice)
        {
            BasketItemId = basketItemId;
            NewUnitPrice = newUnitPrice;
        }
    }
}
