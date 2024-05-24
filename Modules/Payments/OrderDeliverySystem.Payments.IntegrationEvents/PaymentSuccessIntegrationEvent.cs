using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.IntegrationEvents
{
    public class PaymentSuccessIntegrationEvent : IntegrationEvent
    {
        public Guid PaymentId { get; }
        public Guid OrderId { get; }

        public PaymentSuccessIntegrationEvent(Guid paymentId, Guid orderId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
        }
    }
}
