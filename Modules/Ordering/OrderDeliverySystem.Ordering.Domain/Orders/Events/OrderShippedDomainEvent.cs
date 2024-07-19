using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderShippedDomainEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public Guid BuyerId { get; }

        public OrderShippedDomainEvent(OrderId orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;
        }
    }
}
