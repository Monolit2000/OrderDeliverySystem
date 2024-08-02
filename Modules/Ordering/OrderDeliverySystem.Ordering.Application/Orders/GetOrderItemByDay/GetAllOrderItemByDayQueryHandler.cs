using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.Orders;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOrderItemByDay
{
    public class GetAllOrderItemByDayQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetAllOrderItemByDayQuery, Result<List<OrderItemDto>>>
    {
        public async Task<Result<List<OrderItemDto>>> Handle(GetAllOrderItemByDayQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            var orderItemsByDay = orders
                .SelectMany(o => o.OrderItems.Select(oi => new { OrderId = o.Id, BuyerId = o.BuyerId, OrderItem = oi }))
                .Where(oi => oi.OrderItem.DeliveryOptions.DeliveryDateTime.Date.Day == request.Deadline.Date.Day)
                .Select(oi => new OrderItemDto
                {
                    OrderId = oi.OrderId.Value, 
                    BuerId = oi.BuyerId,
                    OrderItemId = oi.OrderItem.OrderItemId,
                    ProductName = oi.OrderItem.ProductName,
                    UnitPrice = oi.OrderItem.UnitPrice,
                    Discount = oi.OrderItem.Discount,
                    Units = oi.OrderItem.Units,
                    Deadline = oi.OrderItem.DeliveryOptions.DeliveryDateTime,
                   // Address = oi.OrderItem.DeliveryOptions.Address
                })
                .ToList();

            if (!orderItemsByDay.Any())
            {
                return Result.Fail("No order items found for the specified delivery date.");
            }

            return Result.Ok(orderItemsByDay);
        }
    }
}
