using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.Orders;
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
            .Select(o => new OrderDto
            {
                OrderId = o.Id.Value,
                BuyerId = o.BuyerId,    
                Created = o.OrderDate,
                Status = o.OrderStatus.Value,
                Description = o.Description,
                OrderItems = o.OrderItems
                .Select(item => new OrderItemDto
                {
                    ItemId = item.OrderItemId,
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Units = item.Units
                })
                .ToList()
            })
            .ToList();

            if (order == null)
                return Result.Fail("order not faond by id ");

            return order;
        }
    }
}
