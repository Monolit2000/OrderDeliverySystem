using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Ordering.Domain.Orders.Events
{
    public class OrderPaymentFailedDomainEvent : DomainEventBase
    {
        public Guid BuyerId { get; set; }

        public OrderId OrderId { get; set; }

        public string Reason { get; set; }

        public OrderPaymentFailedDomainEvent(Guid buyerId, OrderId orderId, string reason)
        {
            BuyerId = buyerId;
            OrderId = orderId;
            Reason = reason;
        }
    }
}
