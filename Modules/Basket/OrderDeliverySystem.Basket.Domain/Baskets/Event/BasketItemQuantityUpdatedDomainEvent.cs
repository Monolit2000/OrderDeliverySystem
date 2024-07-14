using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets.Event
{
    public class BasketItemQuantityUpdatedDomainEvent : DomainEventBase
    {
        public Guid BasketItemId { get; }
        public int NewQuantity { get; }

        public BasketItemQuantityUpdatedDomainEvent(Guid basketItemId, int newQuantity)
        {
            BasketItemId = basketItemId;
            NewQuantity = newQuantity;
        }
    }
}
