using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.Payments.DomainEvents
{
    public class PaymentSuccessDomainEvent : DomainEventBase
    {
        public PaymentId PaymentId { get; }
        public OrderId OrderId { get; }

        public PaymentSuccessDomainEvent(PaymentId paymentId, OrderId orderId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
        }
    }
}
