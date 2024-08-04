using Azure.Core;
using FluentResults;
using MediatR;
using OrderDeliverySystem.Payments.Api;
using OrderDeliverySystem.Payments.Api.GetCheckoutUrl;
using OrderDeliverySystem.Payments.Application.Payments.GeneratePaymentUrl;
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
                new GeneratePaymentUrlCommand(
                request.UserId,
                request.OrderId,
                request.Amount,
                request.PaymentDate,
                request.Description));

            var checkoutUri = responce.Value.CheckoutUri;

            return new PaymentCheckoutResponce(request.OrderId, checkoutUri);
        }
    }
}
