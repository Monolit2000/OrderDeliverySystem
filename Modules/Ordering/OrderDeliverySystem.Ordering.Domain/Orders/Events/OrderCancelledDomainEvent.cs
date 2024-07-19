using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderCancelledDomainEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public Guid BuyerId { get; }

        public OrderCancelledDomainEvent(OrderId orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;
        }
    }
}
