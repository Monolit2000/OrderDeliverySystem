using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Payments.Application.Contract;
using FluentResults;
using LiqPay.SDK.Dto;
using Azure.Core;
using LiqPay.SDK;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace OrderDeliverySystem.Payments.Infrastructure.Servises.Peyments
{
    public class CallbacProcessingServise(IConfiguration config) : ICallbackProcessingServise
    {
        public async Task<Result<LiqPayResponse>> ProcessCallback(string data, string signature)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrEmpty(data))
            {
                //Invalid request
                return Result.Fail("Invalid request");
            }

            var liqPayClient = new LiqPayClient(config["LiqPayPublicTestKey"], config["LiqPayPrivateTestKey"]);

            liqPayClient.IsCnbSandbox = true;

            // Generate the signature on the server side
            var generatedSignature = liqPayClient.CreateSignature(data);

            //Compare signatures
            if (generatedSignature != signature)
                return Result.Fail("Invalid signature");


            // Decode the data from Base64
            var dataBytes = Convert.FromBase64String(data);
            var dataString = Encoding.UTF8.GetString(dataBytes);

            var liqPayResponse = JsonConvert.DeserializeObject<LiqPayResponse>(dataString);

            if (liqPayResponse is null)
                return Result.Fail("Invalid liqPay Response");

            return liqPayResponse;
        }
    }
}
