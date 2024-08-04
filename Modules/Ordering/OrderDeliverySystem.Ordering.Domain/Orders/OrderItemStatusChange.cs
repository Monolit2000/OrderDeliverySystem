using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Ordering.Domain.Orders.Events;

namespace OrderDeliverySystem.Ordering.Domain.Orders
{
    public class OrderItemStatusChange : Entity
    {
        public OrderItemStatusChangeId Id { get; private set; }
        public Guid ItemId { get; private set; }
        public OrderItemStatus Status { get; private set; }
        public DateTime ChangedDate { get; private set; }


        private OrderItemStatusChange() { } //For Ef Core

        private OrderItemStatusChange(
            Guid orderItemId, 
            OrderItemStatus status,
            DateTime changedDate)
        {
            Id = new OrderItemStatusChangeId(Guid.NewGuid());
            ItemId = orderItemId;
            Status = status;    
            ChangedDate = changedDate;

            AddDomainEvent(new OrderStatusChangedDomainEvent(orderItemId, status.Value));
        }

        public static OrderItemStatusChange CreateNew(
            Guid orderItemId,
            OrderItemStatus status,
            DateTime changedDate)
        {
            return new OrderItemStatusChange(
                orderItemId,
                status, 
                changedDate);
        }
    }
}
