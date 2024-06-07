using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate.DomainEvents
{
    public class OrderPaymentFailedDomainEvent : DomainEventBase
    {
        public Guid BuyerId { get; set; }

        public Guid OrderId { get; set; }

        public string Reason { get; set; }

        public OrderPaymentFailedDomainEvent(Guid buyerId, Guid orderId, string reason)
        {
            BuyerId = buyerId;
            OrderId = orderId;
            Reason = reason;
        }
    }
}
