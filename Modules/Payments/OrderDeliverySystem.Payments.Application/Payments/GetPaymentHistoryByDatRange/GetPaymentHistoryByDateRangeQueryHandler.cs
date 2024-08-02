using FluentResults;
using MediatR;
using OrderDeliverySystem.Payments.Domain.Payments;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentHistoryByDatRange
{
    public class GetPaymentHistoryByDateRangeQueryHandler(IPaymentRepository paymentRepository) : IRequestHandler<GetPaymentHistoryByDateRangeQuery, Result<List<PaymentHistoryDto>>>
    {
        public async Task<Result<List<PaymentHistoryDto>>> Handle(GetPaymentHistoryByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var payments = await paymentRepository.GetAllPayments();

            var paymentHistoryByDateRange = payments
                .Where(p => p.Date.Date >= request.StartDate.Date
                         && p.Date.Date <= request.EndDate.Date)
                .Select(p => new PaymentHistoryDto
                {
                    PaymentId = p.Id.Value,
                    Amount = p.Amount,
                    Date = p.Date,
                    Status = p.PaymentStatus.Value
                })
                .ToList();

            if (!paymentHistoryByDateRange.Any())
            {
                return Result.Fail("No payment history found for the specified date range.");
            }

            return Result.Ok(paymentHistoryByDateRange);
        }
    }
}
