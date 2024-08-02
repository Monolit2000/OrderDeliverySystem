using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;

namespace OrderDeliverySystem.Ordering.IntegrationEvents
{
    public class OrderCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid BuyerId { get; }

        public OrderCreatedIntegrationEvent(
            Guid orderId, 
            Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;
        }
    }
}
