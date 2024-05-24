using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;

namespace OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl
{
    public class GetPaymentUrlCommandHandler : IRequestHandler<GetPaymentUrlCommand, Result<PaymentUrlDto>>
    {
        private readonly ILogger<GetPaymentUrlCommandHandler> _logger;
        private readonly IPaymentRepository _paymentRepository; 
        private readonly IConfiguration _config;

        public GetPaymentUrlCommandHandler(
            IPaymentRepository paymentRepository,
            ILogger<GetPaymentUrlCommandHandler> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _paymentRepository = paymentRepository;
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
                Description = "Оплата послуг",
            };

            var liqPayClient = new LiqPayClient(_config["LiqPayPublicTestKey"], _config["LiqPayPrivateTestKey"]);

            liqPayClient.IsCnbSandbox = true;

            var paymentDetails = liqPayClient.GenerateDataAndSignature(paymentRequest);

            string сheckoutUri = $"https://www.liqpay.ua/api/3/checkout?data={Uri.EscapeDataString(paymentDetails.Key)}&signature={Uri.EscapeDataString(paymentDetails.Value)}";

            var payment = new Payment(
                request.UserId, 
                request.OrderId,
                request.Amount);

            await _paymentRepository.AddAsync(payment);

            return new PaymentUrlDto(сheckoutUri);
        }
    }
}
