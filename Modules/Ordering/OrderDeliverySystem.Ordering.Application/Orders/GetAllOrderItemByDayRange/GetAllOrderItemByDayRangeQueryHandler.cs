using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.Orders;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetAllOrderItemByDayRange
{
    public class GetAllOrderItemByDayRangeQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetAllOrderItemByDayRangeQuery, Result<List<OrderItemDto>>>
    {
        public async Task<Result<List<OrderItemDto>>> Handle(GetAllOrderItemByDayRangeQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            var orderItemsByDay = orders
                .SelectMany(o => o.OrderItems.Select(oi => new { OrderId = o.Id, Buyer = o.Buyer, OrderItem = oi }))
                .Where(oi => oi.OrderItem.DeliveryOptions.DeliveryDateTime.Date >= request.StartDate.Date
                          && oi.OrderItem.DeliveryOptions.DeliveryDateTime.Date <= request.EndDate.Date)
                .Select(oi => new OrderItemDto
                {
                    OrderId = oi.OrderId.Value,
                    BuyerId = oi.Buyer.BuyerId,
                    PhoneNumber = oi.Buyer.PhoneNumber,
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
                return Result.Fail("No order items found for the specified delivery date range.");
            }

            return Result.Ok(orderItemsByDay);
        }
    }
}
