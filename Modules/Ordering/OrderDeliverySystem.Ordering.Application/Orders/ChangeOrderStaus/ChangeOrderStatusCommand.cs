using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderStaus
{
    public class ChangeOrderStatusCommand : IRequest<Result<ChangeOrderStatusDto>>
    {
        public Guid OrderId { get; set; }

        public string Status { get; set; }
    }
}
