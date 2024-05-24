using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.IntegrationEvents
{
    public class OrderPaidIntegretionEvent : IntegrationEvent
    {
        public Guid BuyerId { get; }

        public OrderPaidIntegretionEvent(Guid buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
