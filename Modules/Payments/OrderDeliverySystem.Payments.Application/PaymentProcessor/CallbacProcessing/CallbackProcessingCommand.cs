using FluentResults;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing
{
    public class CallbackProcessingCommand : IRequest<Result<CallbackProcessingResult>>
    {
        public string Data { get; set; }
        public string Signature { get; set; }

        public CallbackProcessingCommand(string data, string signature)
        {
            Data = data;
            Signature = signature;
        }
    }
}
