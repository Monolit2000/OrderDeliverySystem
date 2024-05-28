using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate.DomainEvents
{
    public class PaymentFailedDomainEvent : DomainEventBase
    {
        public Guid PaymentId { get; }
        public Guid OrderId { get; }
        string Resonses { get; }

        public PaymentFailedDomainEvent(Guid paymentId, Guid orderId, string resonses)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Resonses = resonses;    
        }
    }
}
