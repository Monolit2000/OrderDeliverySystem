using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Payments.Domain.Payments;
using OrderDeliverySystem.Payments.Domain.Payers;

namespace OrderDeliverySystem.Payments.Application.Payments.GeneratePaymentUrl
{
    public class GeneratePaymentUrlCommandHandler : IRequestHandler<GeneratePaymentUrlCommand, Result<PaymentUrlDto>>
    {
        private readonly ILogger<GeneratePaymentUrlCommandHandler> _logger;
        private readonly IPaymentRepository _paymentRepository; 
        private readonly IConfiguration _config;

        public GeneratePaymentUrlCommandHandler(
            IPaymentRepository paymentRepository,
            ILogger<GeneratePaymentUrlCommandHandler> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _paymentRepository = paymentRepository;
        }

        public async Task<Result<PaymentUrlDto>> Handle(GeneratePaymentUrlCommand request, CancellationToken cancellationToken)
        {
            var paymentRequest = new LiqPayRequest
            {
                Amount = (double)request.Amount,
                Currency = "UAH",
                OrderId = request.OrderId.ToString(),
                Action = LiqPayRequestAction.Pay,
                Language = LiqPayRequestLanguage.EN,
                ServerUrl = _config["ProcessorCallbackUrl"],
                Version = 3,
                Description = "Оплата послуг",
            };

            var liqPayClient = new LiqPayClient(
                _config["LiqPayPublicTestKey"], 
                _config["LiqPayPrivateTestKey"]);

            liqPayClient.IsCnbSandbox = true;

            var paymentDetails = liqPayClient.GenerateDataAndSignature(paymentRequest);

            string сheckoutUri = $"https://www.liqpay.ua/api/3/checkout?data={Uri.EscapeDataString(paymentDetails.Key)}" +
                $"&signature={Uri.EscapeDataString(paymentDetails.Value)}";

            var payment = Payment.StartPayment(
                new OrderId(request.OrderId),
                new PayerId(request.UserId),
                request.Amount);

            await _paymentRepository.AddAsync(payment);

            return new PaymentUrlDto(сheckoutUri);
        }
    }
}
