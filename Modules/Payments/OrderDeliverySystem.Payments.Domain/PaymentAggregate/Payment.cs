using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate.DomainEvents;
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
        public Guid PayerId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public DateTime PaymentDate { get; private set; }

        private Payment() { }

        public Payment(Guid orderId, Guid payerId, decimal amount)
        {
            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            PayerId = payerId;
            Amount = amount;
            PaymentDate = DateTime.UtcNow;
            PaymentStatus = PaymentStatus.Pending;  
        }

        public Result SuccessPayment()
        {
            PaymentStatus = PaymentStatus.Success;
            //ChangeStatus(PaymentStatus.Success);
            AddDomainEvent(new PaymentSuccessDomainEvent(PaymentId, OrderId));
            return Result.Ok();
        }

        public Result FailPayment(string resonses)
        {
            PaymentStatus = PaymentStatus.Failed;
            //ChangeStatus(PaymentStatus.Failed);
            AddDomainEvent(new PaymentFailedDomainEvent(PaymentId, OrderId, resonses));
            return Result.Ok();
        }

        public Result ChangeStatus(PaymentStatus newStatus)
        {
            var oldStatus = PaymentStatus.Value;
            PaymentStatus = newStatus;
            AddDomainEvent(new PaymentStatusChangedDomainEvent(PaymentId, oldStatus, newStatus.Value));
            return Result.Ok();
        }


    }
}
