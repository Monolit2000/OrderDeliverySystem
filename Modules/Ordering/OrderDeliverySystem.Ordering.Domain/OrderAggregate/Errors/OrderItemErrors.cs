using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate.Errors
{
    public static class OrderItemErrors
    {
        public static readonly string DeliveryTimeTooSoon = "The new delivery time must be at least two hours from now.";
        public static readonly string DeliveryDateMismatch = "The new delivery date must match the originally planned delivery date.";
        public static readonly string AddressChangeTooSoon = "Cannot change delivery address within 1 hour of delivery.";
        public static readonly string EmptyNewAddress = "New address cannot be empty.";
        public static readonly string ProductAlreadyAdded = "Product has already been added.";
    }
}
