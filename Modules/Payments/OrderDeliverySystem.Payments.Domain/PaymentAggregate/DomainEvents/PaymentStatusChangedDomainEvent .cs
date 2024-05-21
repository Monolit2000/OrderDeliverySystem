using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate.DomainEvents
{
    public class PaymentStatusChangedDomainEvent : DomainEventBase
    {
        public Guid PaymentId { get; }
        public string OldStatus { get; }
        public string NewStatus { get; }

        public PaymentStatusChangedDomainEvent(Guid paymentId, string oldStatus, string newStatus)
        {
            PaymentId = paymentId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}
