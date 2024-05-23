using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl
{
    public class GetPaymentUrlCommandHandler : IRequestHandler<GetPaymentUrlCommand, Result<PaymentUrlDto>>
    {
        private readonly ILogger<GetPaymentUrlCommandHandler> _logger;

        private readonly IConfiguration _config;

        public GetPaymentUrlCommandHandler(
            ILogger<GetPaymentUrlCommandHandler> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<Result<PaymentUrlDto>> Handle(GetPaymentUrlCommand request, CancellationToken cancellationToken)
        {
            var paymentRequest = new LiqPayRequest
            {
                Amount = (double)request.Amount,
                Currency = "UAH",
                OrderId = request.OrderId.ToString(),
                Action = LiqPayRequestAction.Pay,
                Language = LiqPayRequestLanguage.EN,
                ServerUrl = _config["ProcessorCallbackUrl"],
                Description = "Test pay",
                Goods = new List<LiqPayRequestGoods>
                {
                    new LiqPayRequestGoods
                    {
                        Amount = 1,
                        Count = 2,
                        Unit = "pcs.",
                        Name = "Order1"
                    }
                }
            };

            var liqPayClient = new LiqPayClient(_config["LiqPayPublicTestKey"], _config["LiqPayPrivateTestKey"]);

            liqPayClient.IsCnbSandbox = true;

            var paymentDetails = liqPayClient.GenerateDataAndSignature(paymentRequest);

            string сheckoutUri = $"https://www.liqpay.ua/api/3/checkout?data={Uri.EscapeDataString(paymentDetails.Key)}&signature={Uri.EscapeDataString(paymentDetails.Value)}";

            var payment = new Payment(
                request.UserId, 
                request.OrderId,
                request.Amount);

            return new PaymentUrlDto(сheckoutUri);
        }
    }
}
