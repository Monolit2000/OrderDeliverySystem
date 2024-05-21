using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl
{
    public class GetPaymentUrlCommand : IRequest<Result<PaymentUrlDto>>
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }

        public GetPaymentUrlCommand() { }

        public GetPaymentUrlCommand(
            Guid paymentId, 
            Guid userId,
            Guid orderId, 
            decimal amount,
            string status,
            DateTime paymentDate)
        {
            PaymentId = paymentId;
            UserId = userId;
            OrderId = orderId;
            Amount = amount;
            Status = status;
            PaymentDate = paymentDate;
        }

    }
}
