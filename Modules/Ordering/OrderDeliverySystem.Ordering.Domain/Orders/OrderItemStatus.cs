using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Ordering.Domain.Orders
{
    public class OrderItemStatus : ValueObject
    {
        public static OrderItemStatus Waiting => new OrderItemStatus(nameof(Waiting));
        public static OrderItemStatus Paid => new OrderItemStatus(nameof(Paid));
        public static OrderItemStatus Failed => new OrderItemStatus(nameof(Failed));
        public static OrderItemStatus PickedUp => new OrderItemStatus(nameof(PickedUp));
        public static OrderItemStatus Delivered => new OrderItemStatus(nameof(Delivered));
        public static OrderItemStatus Cooked => new OrderItemStatus(nameof(Cooked));
        public static OrderItemStatus InWork => new OrderItemStatus(nameof(InWork));

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Waiting),
            nameof(Paid),
            nameof(Failed),
            nameof(PickedUp),
            nameof(Delivered),
            nameof(Cooked),
            nameof(InWork)
        };
        private OrderItemStatus(string value)
        {
          
            Value = value;
        }

        public string Value { get; }

        public static Result<OrderItemStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid status value: {value}");

            return new OrderItemStatus(value);
        }
    }
}
