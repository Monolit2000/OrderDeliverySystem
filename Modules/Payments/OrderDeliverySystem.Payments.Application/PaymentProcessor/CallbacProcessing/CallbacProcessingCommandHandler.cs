using MediatR;
using FluentResults;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using OrderDeliverySystem.Payments.Domain.Payments;
using OrderDeliverySystem.Payments.Application.Contract;
using OrderDeliverySystem.Payments.Application.Payments.GeneratePaymentUrl;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing
{
    public class CallbacProcessingCommandHandler : IRequestHandler<CallbackProcessingCommand, Result<CallbackProcessingResult>>
    {
        private readonly ILogger<GeneratePaymentUrlCommandHandler> _logger;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IConfiguration _config;
        private readonly ICallbackProcessingServise _callbackProcessingService;

        public CallbacProcessingCommandHandler(
            IPaymentRepository paymentRepository,
            ILogger<GeneratePaymentUrlCommandHandler> logger,
            IConfiguration config,
            ICallbackProcessingServise callbacProcessingServise)
        {
            _logger = logger;
            _config = config;
            _paymentRepository = paymentRepository;
            _callbackProcessingService = callbacProcessingServise;
        }

        public async Task<Result<CallbackProcessingResult>> Handle(CallbackProcessingCommand request, CancellationToken cancellationToken)
        {
            var result = await _callbackProcessingService.ProcessCallback(request.Data, request.Signature);
            if (result.IsFailed)
                return Result.Fail(result.Errors);

            var liqPayResponse = result.Value;
            if (!Guid.TryParse(liqPayResponse.OrderId, out var orderId))
                return Result.Fail("Invalid Order ID");

            var payment = await _paymentRepository.GetByOrderIdAsync(orderId);
            if (payment is null)
                return Result.Fail("Payment not found");

            ProcessPayment(payment, liqPayResponse);

            await _paymentRepository.SaveChangesAsync();

            return Result.Ok(new CallbackProcessingResult());
        }

        private void ProcessPayment(Payment payment, LiqPayResponse liqPayResponse)
        {
            switch (liqPayResponse.Status)
            {
                case LiqPayResponseStatus.Sandbox:
                case LiqPayResponseStatus.Success:
                    payment.SuccessPayment();
                    break;
                case LiqPayResponseStatus.Failure:
                default:
                    payment.FailPayment(liqPayResponse.ErrorDescription);
                    break;
            }
        }
    }
}
