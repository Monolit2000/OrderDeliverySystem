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
        public Guid UserId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime PaymentDate { get; private set; }

        private Payment() { }

        public Payment(Guid orderId, Guid userId, decimal amount)
        {
            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            UserId = userId;
            Amount = amount;
            PaymentDate = DateTime.UtcNow;
        }

        public Result CompletePayment()
        {
            if (Status != PaymentStatus.Pending)
            {
                Result.Fail("Payment can only be completed if it is pending.");
            }

            ChangeStatus(PaymentStatus.Completed);
            AddDomainEvent(new PaymentCompletedDomainEvent(PaymentId, OrderId));
            return Result.Ok();
        }

        public Result FailPayment()
        {
            if (Status != PaymentStatus.Pending)
            {
                Result.Fail("Payment can only be failed if it is pending.");
            }

            ChangeStatus(PaymentStatus.Failed);
            AddDomainEvent(new PaymentFailedDomainEvent(PaymentId, OrderId));
            return Result.Ok();
        }

        public Result ChangeStatus(PaymentStatus newStatus)
        {
            var oldStatus = Status.Value;
            Status = newStatus;
            AddDomainEvent(new PaymentStatusChangedDomainEvent(PaymentId, oldStatus, newStatus.Value));
            return Result.Ok();
        }


    }
}
