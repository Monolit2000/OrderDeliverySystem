using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentStatus
{
    public class GetPaymentStatusQuery : IRequest<Result<PaymentStatusDto>>
    {
        public string OrderId { get; set; }
    }
}
