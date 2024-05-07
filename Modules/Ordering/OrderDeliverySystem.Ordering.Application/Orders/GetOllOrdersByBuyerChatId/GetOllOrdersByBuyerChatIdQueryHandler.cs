using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId
{
    public class GetOllOrdersByBuyerChatIdQueryHandler : IRequestHandler<GetOllOrdersByBuyerChatIdQuery, Result<List<OrderDto>>>
    {
        public readonly IOrderRepository _orderRepository;

        public GetOllOrdersByBuyerChatIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<OrderDto>>> Handle(GetOllOrdersByBuyerChatIdQuery request, CancellationToken cancellationToken)
        {

            var root = await _orderRepository.GetOllOrderAsyncByChatId(request.ChatId);

            if (root == null)
                return Result.Fail("order not faond by id ");

            var order = root
            .Select(order => new OrderDto
            {
                OrderId = order.OrderId,
                Created = order.OrderDate,
                Status = order.OrderStatus.Value,
                Description = order.Description,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ItemId = item.OrderItemId,
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Units = item.Units
                }).ToList()
            })
            .ToList();

            if (order == null)
                return Result.Fail("order not faond by id ");

            return order;
        }
    }
}
