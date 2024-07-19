using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderPaidDomainEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public Guid BuyerId { get; }

        public OrderPaidDomainEvent(OrderId orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;  
        }
    }
}
