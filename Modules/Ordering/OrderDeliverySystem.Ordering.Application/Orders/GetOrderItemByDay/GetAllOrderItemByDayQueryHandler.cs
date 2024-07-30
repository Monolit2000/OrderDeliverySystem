using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.Orders;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOrderItemByDay
{
    public class GetAllOrderItemByDayQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetAllOrderItemByDayQuery, Result<OrderItemByDayDto>>
    {
        public async Task<Result<OrderItemByDayDto>> Handle(GetAllOrderItemByDayQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            var orderItemsByDay = orders
                .SelectMany(o => o.OrderItems)
                .Where(oi => oi.DeliveryOptions.DeliveryDateTime.Date.Day == request.Deadline.Date.Day)
                .Select(oi => new OrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    ProductName = oi.ProductName,
                    UnitPrice = oi.UnitPrice,
                    Discount = oi.Discount,
                    Units = oi.Units,
                    Deadline = oi.DeliveryOptions.DeliveryDateTime,
                    //Address = oi.DeliveryOptions.Address
                })
                .ToList();

            if (!orderItemsByDay.Any())
            {
                return Result.Fail("No order items found for the specified delivery date.");
            }

            var orderItemByDayDto = new OrderItemByDayDto
            {
                OrderItems = orderItemsByDay
            };

            return Result.Ok(orderItemByDayDto);
        }
    }
}
