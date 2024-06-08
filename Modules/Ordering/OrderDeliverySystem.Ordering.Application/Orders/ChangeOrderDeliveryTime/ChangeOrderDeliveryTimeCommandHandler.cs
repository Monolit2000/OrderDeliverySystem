using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderDeliveryTime
{
    public class ChangeOrderDeliveryTimeCommandHandler : IRequestHandler<ChangeOrderDeliveryTimeCommand, Result<ChangeOrderDeliveryTimeResult>>
    {
        public Task<Result<ChangeOrderDeliveryTimeResult>> Handle(ChangeOrderDeliveryTimeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
