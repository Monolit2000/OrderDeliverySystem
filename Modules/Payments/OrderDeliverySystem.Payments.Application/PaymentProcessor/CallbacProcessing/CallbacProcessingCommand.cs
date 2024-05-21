using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing
{
    public class CallbacProcessingCommand : IRequest<Result<CallbacProcessingResult>>
    {
        public string Data { get; set; }
        public string Signature { get; set; }

        public CallbacProcessingCommand(string data, string signature)
        {
            Data = data;
            Signature = signature;
        }
    }
}
