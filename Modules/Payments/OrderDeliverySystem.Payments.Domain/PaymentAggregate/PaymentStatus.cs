using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate
{
    public class PaymentStatus : ValueObject
    {
        public static PaymentStatus Pending => new PaymentStatus(nameof(Pending));

        public static PaymentStatus Success => new PaymentStatus(nameof(Success));

        public static PaymentStatus Failed => new PaymentStatus(nameof(Failed));

        public string Value { get; }

        private PaymentStatus(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("PaymentStatus cannot be empty or null.", nameof(Value));
            }

            Value = value;
        }

        public static Result<PaymentStatus> FromString(string status)
        {
            return status switch
            {
                "Pending" => Pending,
                "Success" => Success,
                "Failed" => Failed,
                _ => Result.Fail($"Invalid payment status: {status}")
            };
        }
    }
}
