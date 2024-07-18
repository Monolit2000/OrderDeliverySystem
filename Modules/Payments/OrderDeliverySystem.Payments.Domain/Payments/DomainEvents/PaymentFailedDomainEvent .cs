using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.Payments.DomainEvents
{
    public class PaymentFailedDomainEvent : DomainEventBase
    {
        public PaymentId PaymentId { get; }
        public OrderId OrderId { get; }
        string Resonses { get; }

        public PaymentFailedDomainEvent(PaymentId paymentId, OrderId orderId, string resonses)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Resonses = resonses;    
        }
    }
}
