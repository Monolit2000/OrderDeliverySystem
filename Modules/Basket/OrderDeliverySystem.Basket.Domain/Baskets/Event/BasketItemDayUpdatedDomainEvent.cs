using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets.Event
{
    public class BasketItemDayUpdatedDomainEvent : DomainEventBase
    {
        public Guid BasketItemId { get; }
        public DateTime NewDay { get; }

        public BasketItemDayUpdatedDomainEvent(Guid basketItemId, DateTime newDay)
        {
            BasketItemId = basketItemId;
            NewDay = newDay;
        }
    }
}
