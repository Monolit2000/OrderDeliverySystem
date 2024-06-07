using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;

namespace OrderDeliverySystem.Payments.IntegrationEvents
{
    public class PaymentFailedIntegretionEvent : IntegrationEvent
    {
        public Guid PaymentId { get; }
        public Guid OrderId { get; }

        public PaymentFailedIntegretionEvent(Guid paymentId, Guid orderId)
        {
            PaymentId = paymentId;
            OrderId = orderId;
        }
    }
}
