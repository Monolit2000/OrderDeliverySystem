using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.Payments.Events
{
    public class PaymentPendingDomainEvent : DomainEventBase
    {
        public PaymentId PaymentId { get; }
        public OrderId OrderId { get; }

        public PaymentPendingDomainEvent(PaymentId paymentId, OrderId orderId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
        }
    }
}
