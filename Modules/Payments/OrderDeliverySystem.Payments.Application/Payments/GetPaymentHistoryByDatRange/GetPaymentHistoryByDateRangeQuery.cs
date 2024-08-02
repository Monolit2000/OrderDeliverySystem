using FluentResults;
using MediatR;


namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentHistoryByDatRange
{
    public class GetPaymentHistoryByDateRangeQuery : IRequest<Result<List<PaymentHistoryDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
