using FluentResults;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing
{
    public class CallbacProcessingCommandHandler : IRequestHandler<CallbacProcessingCommand, Result<CallbacProcessingResult>>
    {
        private readonly IConfiguration _config;
        public CallbacProcessingCommandHandler(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Result<CallbacProcessingResult>> Handle(CallbacProcessingCommand request, CancellationToken cancellationToken)
        {

            if (request == null || string.IsNullOrEmpty(request.Data) || string.IsNullOrEmpty(request.Signature))
            {
                //Invalid request
                return Result.Fail("Invalid request");
            }

            // Decode the data from Base64
            var dataBytes = Convert.FromBase64String(request.Data);
            var dataString = Encoding.UTF8.GetString(dataBytes);

            var liqPayClient = new LiqPayClient(_config["LiqPayPublicTestKey"], _config["LiqPayPrivateTestKey"]);

           // Generate the signature on the server side
            var generatedSignature = liqPayClient.CreateSignature(request.Data);

            //Compare signatures
            if (generatedSignature != request.Signature)
            {
                return Result.Fail("Invalid signature");
            }

            var transactionData = JsonConvert.DeserializeObject<LiqPayResponse>(dataString);

            if (transactionData.Status == LiqPay.SDK.Dto.Enums.LiqPayResponseStatus.Success)
            {
                
            }

            var fd = transactionData.Status switch
            {
                LiqPay.SDK.Dto.Enums.LiqPayResponseStatus.Failure => "sd",
            };



            return new CallbacProcessingResult();
        }
    }
}
