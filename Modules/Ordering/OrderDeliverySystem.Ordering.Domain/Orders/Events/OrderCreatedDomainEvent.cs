using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderCreatedDomainEvent : DomainEventBase
    {
        public Guid BuyerId { get; }
        public OrderId OrderId { get; }

        public OrderCreatedDomainEvent(
            Guid buyerId,
            OrderId orderId) 
        {
            BuyerId = buyerId;
            OrderId = orderId;
        }
    }
}
