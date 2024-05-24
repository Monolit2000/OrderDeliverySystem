using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class OrderStatus : ValueObject
    {
        public static OrderStatus Submitted => new OrderStatus(nameof(Submitted));

        public static OrderStatus AwaitingValidation => new OrderStatus(nameof(AwaitingValidation));

        public static OrderStatus Paid => new OrderStatus(nameof(Paid));

        public static OrderStatus Shipped => new OrderStatus(nameof(Shipped));

        public static OrderStatus Cancelled => new OrderStatus(nameof(Cancelled));

        public string Value { get; }

        private OrderStatus(string value)
        {
            Value = value;
        }

        public static Result<OrderStatus> FromString(string status)
        {
            return status switch
            {
                "Submitted" => Submitted,
                "AwaitingValidation" => AwaitingValidation,
                "Paid" => Paid,
                "Shipped" => Shipped,
                "Cancelled" => Cancelled,
                
                _ => Result.Fail($"Invalid payment status: {status}")
            };
        }



    }
}
