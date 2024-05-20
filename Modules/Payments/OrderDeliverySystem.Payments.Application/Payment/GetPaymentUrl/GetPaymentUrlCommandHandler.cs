using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payment.GetPaymentUrl
{
    public class GetPaymentUrlCommandHandler : IRequestHandler<GetPaymentUrlCommand, Result<PaymentUrlDto>>
    {
        private ILogger<GetPaymentUrlCommandHandler> _logger;

        public GetPaymentUrlCommandHandler(ILogger<GetPaymentUrlCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task<Result<PaymentUrlDto>> Handle(GetPaymentUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
