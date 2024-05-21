using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing
{
    public class CallbacProcessingCommandHandler : IRequestHandler<CallbacProcessingCommand, Result<CallbacProcessingResult>>
    {
        public async Task<Result<CallbacProcessingResult>> Handle(CallbacProcessingCommand request, CancellationToken cancellationToken)
        {



            return new CallbacProcessingResult();
        }
    }
}
