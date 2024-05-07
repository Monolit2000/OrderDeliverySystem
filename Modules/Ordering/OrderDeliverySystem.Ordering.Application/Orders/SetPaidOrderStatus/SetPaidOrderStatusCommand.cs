using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus
{
    public class SetPaidOrderStatusCommand : IRequest<Result<SetPaidOrderStatusDto>>
    {
        public Guid OrderId { get; set; }
    }
}
