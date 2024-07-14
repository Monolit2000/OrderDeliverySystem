using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets.Event
{
    public class BasketItemDeliverySetDomainEvent : DomainEventBase
    {
        public Guid BasketItemId { get; }
        public bool IsDelivery { get; }
        public DateTime DeliveryDateTime { get; }

        public BasketItemDeliverySetDomainEvent(Guid basketItemId, bool isDelivery, DateTime deliveryDateTime)
        {
            BasketItemId = basketItemId;
            IsDelivery = isDelivery;
            DeliveryDateTime = deliveryDateTime;
        }
    }
}
