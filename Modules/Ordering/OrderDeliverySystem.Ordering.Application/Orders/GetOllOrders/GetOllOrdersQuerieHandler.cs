using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOllOrders
{
    public class GetOllOrdersQuerieHandler : IRequestHandler<GetOllOrdersQuerie, Result<List<OrderDto>>>
    {
        public readonly IOrderRepository _orderRepository;

        public GetOllOrdersQuerieHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<OrderDto>>> Handle(GetOllOrdersQuerie request, CancellationToken cancellationToken)
        {
            var root = await _orderRepository.GetOllOrders();

            if (root == null)
                return Result.Fail("ordersDto not faond by id ");

            var ordersDto = root
            .Select(order => new OrderDto
            {
                OrderId = order.OrderId,
                BuyerId = order.BuyerId,
                Created = order.OrderDate,
                Status = order.OrderStatus.Value,
                Description = order.Description,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ItemId = item.OrderItemId,
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Units = item.Units
                })
                .ToList()
            })
            .ToList();

            return ordersDto;
        }
    }
}
