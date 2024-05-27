using FluentResults;
using LiqPay.SDK.Dto.Enums;
using LiqPay.SDK.Dto;
using LiqPay.SDK;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentStatus
{
    public class GetPaymentStatusQueryHandler : IRequestHandler<GetPaymentStatusQuery, Result<PaymentStatusDto>>
    {
        private readonly ILogger<GetPaymentUrlCommandHandler> _logger;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IConfiguration _config;

        public GetPaymentStatusQueryHandler(
            IPaymentRepository paymentRepository,
            ILogger<GetPaymentUrlCommandHandler> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _paymentRepository = paymentRepository;
        }

        public async Task<Result<PaymentStatusDto>> Handle(GetPaymentStatusQuery request, CancellationToken cancellationToken)
        {
            var checkPaymentRequest = new LiqPayRequest
            {
                Action = LiqPayRequestAction.Status,
                OrderId = request.OrderId,
                Language = LiqPayRequestLanguage.EN,
                ServerUrl = _config["ProcessorCallbackUrl"],
                PublicKey = _config["LiqPayPublicTestKey"],
                Version = 3
                
            };

            var liqPayClient = new LiqPayClient(_config["LiqPayPublicTestKey"], _config["LiqPayPrivateTestKey"]);

            //liqPayClient.IsCnbSandbox = true;

            var result = await liqPayClient.RequestAsync("request", checkPaymentRequest);

            var status = result.Status.ToString();

            return new PaymentStatusDto { Status = status };
        }
    }
}
