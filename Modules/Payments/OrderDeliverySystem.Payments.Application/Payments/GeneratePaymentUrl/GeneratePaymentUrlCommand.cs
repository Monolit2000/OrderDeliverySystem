using FluentResults;
using MediatR;

namespace OrderDeliverySystem.Payments.Application.Payments.GeneratePaymentUrl
{
    public class GeneratePaymentUrlCommand : IRequest<Result<PaymentUrlDto>>
    {
        public Guid UserId { get;  }
        public Guid OrderId { get;  }
        public decimal Amount { get; }
        public DateTime PaymentDate { get; }
        public string? Description { get; } 

        public GeneratePaymentUrlCommand(
            Guid userId,
            Guid orderId,
            decimal amount,
            DateTime paymentDate,
            string? description = null) 
        {
            UserId = userId;
            OrderId = orderId;
            Amount = amount;
            PaymentDate = paymentDate;
            Description = description;
        }
    }
}