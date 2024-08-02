using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Value { get; }

        private OrderItemStatus(string value)
        {
            Value = value;
        }

    }
}
