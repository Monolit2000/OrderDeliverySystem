using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing
{
    public class CallbacProcessingCommandHandler : IRequestHandler<CallbacProcessingCommand, Result<CallbacProcessingResult>>
    {
        private readonly ILogger<GetPaymentUrlCommandHandler> _logger;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IConfiguration _config;

        public CallbacProcessingCommandHandler(
            IPaymentRepository paymentRepository,
            ILogger<GetPaymentUrlCommandHandler> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _paymentRepository = paymentRepository;
        }

        public async Task<Result<CallbacProcessingResult>> Handle(CallbacProcessingCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Data) || string.IsNullOrEmpty(request.Signature))
            {
                //Invalid request
                return Result.Fail("Invalid request");
            }

            var liqPayClient = new LiqPayClient(_config["LiqPayPublicTestKey"], _config["LiqPayPrivateTestKey"]);

            liqPayClient.IsCnbSandbox = true;

            // Generate the signature on the server side
            var generatedSignature = liqPayClient.CreateSignature(request.Data);

            //Compare signatures
            if (generatedSignature != request.Signature)
                return Result.Fail("Invalid signature");
            

            // Decode the data from Base64
            var dataBytes = Convert.FromBase64String(request.Data);
            var dataString = Encoding.UTF8.GetString(dataBytes);

            var liqPayResponse = JsonConvert.DeserializeObject<LiqPayResponse>(dataString);

            Guid result = Guid.Parse(liqPayResponse.OrderId);

            var payment = await _paymentRepository.GetByOrderIdAsync(result);

            if (payment is null)
                return Result.Fail("Payment not found");

            payment.SuccessPayment();

            switch (liqPayResponse.Status)
            {
                case LiqPayResponseStatus.Sandbox:
                case LiqPayResponseStatus.Success:
                    payment.SuccessPayment();
                    break;
                case LiqPayResponseStatus.Failure:
                    payment.FailPayment(liqPayResponse.ErrorDescription);
                    break;
                default:
                    return Result.Fail("Unhandled payment status");
            }

            await _paymentRepository.SaveChangesAsync();

            return new CallbacProcessingResult();
        }
    }
}
