using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate
{
    public class Payment : Entity, IAggregateRoot
    {
        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Method { get; private set; }
        public DateTime PaymentDate { get; private set; }

        private Payment() { }

        public Payment(Guid orderId, decimal amount, PaymentStatus method)
        {
            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Method = method;
            PaymentDate = DateTime.UtcNow;
        }
    }
}
