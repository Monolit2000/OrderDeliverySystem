using FluentResults;
using MediatR;
using OrderDeliverySystem.Payments.Domain.Payers;
using OrderDeliverySystem.Payments.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentHistory
{
    public class GetPaymentHistoryQueryHandler(
        IPaymentRepository paymentRepository) : IRequestHandler<GetPaymentHistoryQuery, Result<List<PaymentHistoryDto>>>
    {
        public async Task<Result<List<PaymentHistoryDto>>> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
        {

            var payments = await paymentRepository.GetPaymentsByUserId(new PayerId(request.PayerId));

            return payments.Select(payment => new PaymentHistoryDto
            {
                PaymentId = payment.Id.Value,
                Amount = payment.Amount,
                Date = payment.Date,
                Status = payment.PaymentStatus.Value,
            }).ToList();
        }
    }
}
