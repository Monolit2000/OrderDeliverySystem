using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;

namespace OrderDeliverySystem.Payments.IntegrationEvents
{
    public class PaymentFailedIntegretionEvent : IntegrationEvent
    {
        public PaymentFailedIntegretionEvent()
        {
        }
    }
}
