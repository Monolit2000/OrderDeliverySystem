using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate.DomainEvents
{
    public class PaymentSuccessDomainEvent : DomainEventBase
    {
        public Guid PaymentId { get; }
        public Guid OrderId { get; }

        public PaymentSuccessDomainEvent(Guid paymentId, Guid orderId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
        }
    }
}
