using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Payments.Domain.Payments;
using OrderDeliverySystem.Payments.Domain.Payers;
using OrderDeliverySystem.Payments.Application.Contract;

namespace OrderDeliverySystem.Payments.Application.Payments.GeneratePaymentUrl
{
    public class GeneratePaymentUrlCommandHandler : IRequestHandler<GeneratePaymentUrlCommand, Result<PaymentUrlDto>>
    {
        private readonly ILogger<GeneratePaymentUrlCommandHandler> _logger;
        private readonly IPaymentRepository _paymentRepository; 
        private readonly IConfiguration _config;
        private readonly ILiqPayService _liqPayService;

        public GeneratePaymentUrlCommandHandler(
            IPaymentRepository paymentRepository,
            ILogger<GeneratePaymentUrlCommandHandler> logger,
            IConfiguration config,
            ILiqPayService liqPayService)
        {
            _logger = logger;
            _config = config;
            _paymentRepository = paymentRepository;
            _liqPayService = liqPayService;
        }

        public async Task<Result<PaymentUrlDto>> Handle(GeneratePaymentUrlCommand request, CancellationToken cancellationToken)
        {
            var сheckoutUri = _liqPayService.GeneratePaymentUrl(
                (double)request.Amount, 
                request.OrderId,
                request.Description);

            var payment = Payment.StartPayment(
                new OrderId(request.OrderId),
                new PayerId(request.UserId),
                request.Amount);

            await _paymentRepository.AddAsync(payment);

            var paymentUrlDto = new PaymentUrlDto(сheckoutUri);

            return paymentUrlDto;
        }
    }
}
