using FluentResults;
using MediatR;
using OrderDeliverySystem.Payments.Application.Payments.GeneratePaymentUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentHistory
{
    public class GetPaymentHistoryQuery : IRequest<Result<List<PaymentHistoryDto>>>
    {
        public Guid PayerId{ get; set; }
        public GetPaymentHistoryQuery(Guid payerId) => 
            PayerId = payerId;
    }
}
