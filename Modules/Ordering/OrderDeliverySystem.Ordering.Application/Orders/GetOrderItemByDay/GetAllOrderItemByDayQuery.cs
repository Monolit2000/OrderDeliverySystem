using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOrderItemByDay
{
    public class GetAllOrderItemByDayQuery : IRequest<Result<List<OrderItemDto>>>
    {
        public DateTime Deadline { get; set; }
    
    }
}
