using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderItemStatusChangedDomainEvent : DomainEventBase
    {
        public Guid OrderItemId { get; }
        public OrderItemStatus Status { get; }

        public OrderItemStatusChangedDomainEvent(
            Guid orderItemId, 
            OrderItemStatus status)
        {
            OrderItemId = orderItemId;
            Status = status;
        }
    }
}
