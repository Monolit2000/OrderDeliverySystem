using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Ordering.Domain.Orders.Events;
using OrderDeliverySystem.Ordering.Domain.Orders.Errors;

namespace OrderDeliverySystem.Ordering.Domain.Orders
{
    public class OrderItem : Entity
    {
        public Guid OrderItemId { get; private set; }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string PictureUrl { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public int Units { get; private set; }

        private readonly List<OrderItemStatusChange> _orderItemStatusChanges = new();

        public IReadOnlyCollection<OrderItemStatusChange> OrderItemStatusChanges => _orderItemStatusChanges.AsReadOnly();

        public OrderItemStatus Status { get; private set; }

        public DeliveryOptions DeliveryOptions { get; private set; }

        public string OptionItemName { get; private set; }
        public decimal OptionItemPrice { get; private set; }
        public int OptionItemQuantity { get; private set; } = 1;

        private OrderItem() { }

        public OrderItem(
            Guid orderItemId,
            string productName,
            decimal unitPrice,
            decimal discount,
            string pictureUrl,
            int units = 1,
            string optionItemName = null,
            decimal optionItemPrice = 0)
        {
            ProductId = orderItemId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Discount = discount;
            Units = units;
            PictureUrl = pictureUrl;
            Status = OrderItemStatus.Waiting;
            DeliveryOptions = DeliveryOptions.SelfPickup(DateTime.Now, "Default");
            OptionItemName = optionItemName;
            OptionItemPrice = optionItemPrice;

            AddDomainEvent(new OrderItemAddedDomainEvent());
        }

        public static OrderItem CreateNew(
            Guid orderItemId,
            string productName,
            decimal unitPrice,
            decimal discount,
            string pictureUrl,
            int units = 1,
            string optionItemName = null,
            decimal optionItemNamePrice = 0)
        {
            return new OrderItem(
                orderItemId,
                productName,
                unitPrice,
                discount,
                pictureUrl,
                units,
                optionItemName,
                optionItemNamePrice);
        }

        public Result ChangeStatus(OrderItemStatus newStatus)
        {
            Result result = newStatus.Value switch
            {
                nameof(OrderItemStatus.Waiting) => MarkAsWaiting(),
                nameof(OrderItemStatus.Paid) => MarkAsPaid(),
                nameof(OrderItemStatus.Failed) => MarkAsFailed(),
                nameof(OrderItemStatus.PickedUp) => MarkAsPickedUp(),
                nameof(OrderItemStatus.Delivered) => MarkAsDelivered(),
                nameof(OrderItemStatus.Cooked) => MarkAsCooked(),
                nameof(OrderItemStatus.InWork) => MarkAsInWork(),
                nameof(OrderItemStatus.Cancelled) => MarkAsCancelled(),
                _ => Result.Fail($"Unhandled status value: {newStatus.Value}")
            };

            return result;
        }

        public Result MarkAsCancelled()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.Cancelled))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.Cancelled;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsCancelledDomainEvent());
            return Result.Ok();
        }

        public Result MarkAsWaiting()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.Waiting))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.Waiting;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsWaitingDomainEvent());
            return Result.Ok();
        }

        public Result MarkAsPaid()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.Paid))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.Paid;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsAsPaidDomainEvent());

            return Result.Ok();
        }

        public Result MarkAsFailed()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.Failed))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.Failed;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsFailedDomainEvent());

            return Result.Ok();
        }

        public Result MarkAsPickedUp()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.PickedUp))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.PickedUp;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsPickedUpDomainEvent());
            return Result.Ok();
        }

        public Result MarkAsDelivered()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.Delivered))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.Delivered;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsDeliveredDomainEvent());
            return Result.Ok();
        }

        public Result MarkAsCooked()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.Cooked))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.Cooked;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsCookedDomainEvent());
            return Result.Ok();
        }

        public Result MarkAsInWork()
        {
            if (ValidateStatusTransition(Status, OrderItemStatus.InWork))
                return Result.Fail("Validate status transition error");

            Status = OrderItemStatus.InWork;
            AddStatusChange(this.OrderItemId, Status);
            AddDomainEvent(new OrderItemMarkedAsInWorkDomainEvent());
            return Result.Ok();
        }

        private void AddStatusChange(Guid itemId, OrderItemStatus newStatus)
        {
            var statusChange = OrderItemStatusChange.CreateNew(itemId, newStatus, DateTime.UtcNow);
            _orderItemStatusChanges.Add(statusChange);
            AddDomainEvent(new OrderItemStatusChangedDomainEvent(OrderItemId, Status));
        }

        public Result SetDefoultDeliveryOptions(DateTime dateTime, string selfPickupAddress)
        {
            DeliveryOptions = DeliveryOptions.SelfPickup(dateTime, selfPickupAddress);
            return Result.Ok();
        }

        public Result AddDeliveryProrerty(DateTime dateTime, string address)
        {
            DeliveryOptions = DeliveryOptions.Delivery(dateTime, address, 20);
            return Result.Ok();
        }

        public Result ChangeDeliveryTime(DateTime newDeliveryDateTime)
        {
            if (DeliveryOptions.DeliveryDateTime < DateTime.Now.AddHours(1))
            {
                return Result.Fail(OrderItemErrors.DeliveryTimeTooSoon);
            }

            if (newDeliveryDateTime.Date != DeliveryOptions.DeliveryDateTime.Date)
            {
                return Result.Fail(OrderItemErrors.DeliveryDateMismatch);
            }

            DeliveryOptions = DeliveryOptions.Delivery(
                newDeliveryDateTime,
                DeliveryOptions.Address,
                DeliveryOptions.DeliveryCost);

            return Result.Ok();
        }

        public Result ChangeDeliveryAddress(string newAddress)
        {
            if (DeliveryOptions.DeliveryDateTime < DateTime.Now.AddHours(1))
            {
                return Result.Fail(OrderItemErrors.AddressChangeTooSoon);
            }

            if (string.IsNullOrEmpty(newAddress))
            {
                return Result.Fail(OrderItemErrors.EmptyNewAddress);
            }

            DeliveryOptions = DeliveryOptions.Delivery(
                DeliveryOptions.DeliveryDateTime,
                newAddress,
                DeliveryOptions.DeliveryCost);

            return Result.Ok();
        }

        private bool ValidateStatusTransition(OrderItemStatus currentStatus, OrderItemStatus newStatus)
        {
            var validTransitions = new Dictionary<OrderItemStatus, List<OrderItemStatus>>
            {
                { OrderItemStatus.Waiting, new List<OrderItemStatus>() },
                { OrderItemStatus.InWork, new List<OrderItemStatus>() },
                { OrderItemStatus.Cooked, new List<OrderItemStatus>() },
                { OrderItemStatus.PickedUp, new List<OrderItemStatus>() },
                { OrderItemStatus.Paid, new List<OrderItemStatus>() },
                { OrderItemStatus.Cancelled, new List<OrderItemStatus>() },
            };

            return currentStatus == newStatus ||
                validTransitions.TryGetValue(currentStatus, out var possibleStatuses) &&
                possibleStatuses.Contains(newStatus);
        }
    }
}
