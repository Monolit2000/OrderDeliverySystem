using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.GetAllOrdersByBuyerChatId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetAllOrders
{
    public class GetAllOrdersQuerie : IRequest<Result<List<OrderDto>>>
    {
    }
}
