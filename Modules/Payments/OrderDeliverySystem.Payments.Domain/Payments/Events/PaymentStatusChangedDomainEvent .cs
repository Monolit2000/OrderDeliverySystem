using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.Payments.Events
{
    public class PaymentStatusChangedDomainEvent : DomainEventBase
    {
        public PaymentId PaymentId { get; }
        public string OldStatus { get; }
        public string NewStatus { get; }

        public PaymentStatusChangedDomainEvent(PaymentId paymentId, string oldStatus, string newStatus)
        {
            PaymentId = paymentId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}
