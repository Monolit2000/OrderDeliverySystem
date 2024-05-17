using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOllOrders
{
    public class GetOllOrdersQuerie : IRequest<Result<List<OrderDto>>>
    {
    }
}
