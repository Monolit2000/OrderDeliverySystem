using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate.DomainEvents
{
    public class OrderCancelledDomainEvent : DomainEventBase
    {
        public Guid OrderId { get; }

        public Guid BuyerId { get; }

        public OrderCancelledDomainEvent(Guid orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;
        }
    }
}
