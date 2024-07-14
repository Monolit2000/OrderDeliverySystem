using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets.Event
{
    public class BasketItemProductInfoUpdatedDomainEvent : DomainEventBase
    {
        public Guid BasketItemId { get; }
        public string NewProductName { get; }
        public string NewProductImageUrl { get; }

        public BasketItemProductInfoUpdatedDomainEvent(Guid basketItemId, string newProductName, string newProductImageUrl)
        {
            BasketItemId = basketItemId;
            NewProductName = newProductName;
            NewProductImageUrl = newProductImageUrl;
        }
    }
}
