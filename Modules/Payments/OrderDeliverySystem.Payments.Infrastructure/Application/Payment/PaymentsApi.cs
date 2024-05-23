using Azure.Core;
using FluentResults;
using MediatR;
using OrderDeliverySystem.Payments.Api;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Infrastructure.Application.Payment
{
    public class PaymentsApi : IPaymentsApi
    {
        public readonly IMediator _mediator;

        public PaymentsApi(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<PaymentCheckoutResponce>> GetCheckoutUrl(GetCheckoutUrlRequest request)
        {
            var responce = await _mediator.Send(
                new GetPaymentUrlCommand(
                request.UserId,
                request.OrderId,
                request.Amount,
                request.PaymentDate));

            return new PaymentCheckoutResponce(request.OrderId, responce.Value.CheckoutUri);
        }
    }
}
