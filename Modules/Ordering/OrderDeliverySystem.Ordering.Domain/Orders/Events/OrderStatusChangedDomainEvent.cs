using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderStatusChangedDomainEvent : DomainEventBase
    {
        public Guid OrderItemId { get; }
        public string OldStatus { get; }
        public string NewStatus { get; }

        public OrderStatusChangedDomainEvent(
            Guid orderItemId,
            string newStatus)
        {
            OrderItemId = orderItemId;
            NewStatus = newStatus;
        }

    }
}
