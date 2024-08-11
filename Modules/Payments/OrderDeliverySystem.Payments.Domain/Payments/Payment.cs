using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Payments.Domain.Payers;
using OrderDeliverySystem.Payments.Domain.Payments.Events;

namespace OrderDeliverySystem.Payments.Domain.Payments
{
    public class Payment : Entity, IAggregateRoot
    {
        public PayerId PayerId { get; private set; }
        public OrderId OrderId { get; private set; }

        public PaymentId Id { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public DateTime Date { get; private set; }

        private Payment() { }

        private Payment(
            OrderId orderId, 
            PayerId payerId, 
            decimal amount)
        {
            Id = new PaymentId(Guid.NewGuid());
            OrderId = orderId;
            PayerId = payerId;
            Amount = amount;
            Date = DateTime.UtcNow;
            PaymentStatus = PaymentStatus.Pending;

            AddDomainEvent(new PaymentCreatedDomainEvent());
        }

        public static Payment CreateNew(
            OrderId orderId,
            PayerId payerId,
            decimal amount)
        {
            return new Payment(
                orderId, 
                payerId, 
                amount);
        }

        public static Payment StartPayment(
            OrderId orderId,
            PayerId payerId,
            decimal amount)
        {
            return new Payment(
                orderId,
                payerId,
                amount);
        }

        public Result SuccessPayment()
        {
            PaymentStatus = PaymentStatus.Success;

            AddDomainEvent(new PaymentSuccessDomainEvent(Id, OrderId));
            return Result.Ok();
        }

        public Result FailPayment(string reasons)
        {
            PaymentStatus = PaymentStatus.Failed;

            AddDomainEvent(new PaymentFailedDomainEvent(Id, OrderId, reasons));
            return Result.Ok();
        }

        public Result ChangeStatus(PaymentStatus newStatus)
        {
            var oldStatus = PaymentStatus.Value;
            PaymentStatus = newStatus;

            AddDomainEvent(new PaymentStatusChangedDomainEvent(Id, oldStatus, newStatus.Value));
            return Result.Ok();
        }


    }
}
