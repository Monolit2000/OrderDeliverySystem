using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate
{
    public class PaymentStatus : ValueObject
    {
        public static PaymentStatus Pending => new PaymentStatus(nameof(Pending));

        public static PaymentStatus Completed => new PaymentStatus(nameof(Completed));

        public static PaymentStatus Failed => new PaymentStatus(nameof(Failed));

        public string Value { get; }

        private PaymentStatus(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Status cannot be empty or null.", nameof(Value));
            }

            Value = value;
        }

        public static PaymentStatus FromString(string status)
        {
            return status switch
            {
                "Pending" => Pending,
                "Completed" => Completed,
                "Failed" => Failed,
                _ => throw new ArgumentException($"Invalid payment status: {status}")
            };
        }
    }
}
