using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderDeliveryTime
{
    public class ChangeOrderDeliveryTimeCommand : IRequest<Result<ChangeOrderDeliveryTimeResult>>
    {
    }
}
