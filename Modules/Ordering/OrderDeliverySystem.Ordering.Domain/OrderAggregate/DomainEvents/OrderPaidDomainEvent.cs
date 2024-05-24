using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate.DomainEvents
{
    public class OrderPaidDomainEvent : DomainEventBase
    {
        public Guid OrderId { get; }

        public Guid BuyerId { get; }

        public OrderPaidDomainEvent(Guid orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;  
        }
    }
}
