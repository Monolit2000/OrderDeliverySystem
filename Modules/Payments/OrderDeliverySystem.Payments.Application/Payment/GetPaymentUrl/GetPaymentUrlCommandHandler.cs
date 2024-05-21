using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payment.GetPaymentUrl
{
    public class GetPaymentUrlCommandHandler : IRequestHandler<GetPaymentUrlCommand, Result<PaymentUrlDto>>
    {
        private ILogger<GetPaymentUrlCommandHandler> _logger;

        public GetPaymentUrlCommandHandler(ILogger<GetPaymentUrlCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<Result<PaymentUrlDto>> Handle(GetPaymentUrlCommand request, CancellationToken cancellationToken)
        {
            var paymentRequest = new LiqPayRequest
            {
                Amount = 1,
                Currency = "UAH",
                OrderId = "order_id",
                Action = LiqPayRequestAction.Pay,
                Language = LiqPayRequestLanguage.EN,
                ServerUrl = "https://localhost:7085/payment/LiqPayCallback",
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

            var liqPayClient = new LiqPayClient("sandbox_i53975565933", "sandbox_kgz4d1g7hvZJl9nKCmMWbOd6vGRCUUdmzmDs97xu");

            liqPayClient.IsCnbSandbox = true;

            //signature and payment data 
            var paymentDetails = liqPayClient.GenerateDataAndSignature(paymentRequest);

            string сheckoutUri = $"https://www.liqpay.ua/api/3/checkout?data={Uri.EscapeDataString(paymentDetails.Key)}&signature={Uri.EscapeDataString(paymentDetails.Value)}";

            return new PaymentUrlDto(сheckoutUri);
        }
    }
}
