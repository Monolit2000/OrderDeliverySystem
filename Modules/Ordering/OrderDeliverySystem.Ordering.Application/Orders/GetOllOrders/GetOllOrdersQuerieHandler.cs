using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId;
using OrderDeliverySystem.Ordering.Domain.Orders;
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
            var orders = await _orderRepository.GetAllOrders();

            if (orders == null)
                return Result.Fail("Orders not faond");

            var ordersDto = orders.Select(order => new OrderDto
            {
                OrderId = order.Id.Value,
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
                }).ToList()
            }).ToList();

            return ordersDto;
        }
    }
}
