using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Helpers;
using OrderDeliverySystem.Ordering.Domain.Orders;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChengeOrderItemStatus
{
    public class ChengeOrderItemStatusCommandHandler(
        IOrderRepository orderRepository) : IRequestHandler<ChengeOrderItemStatusCommand, Result<ChengeOrderItemStatusResultDto>>
    {
        public async Task<Result<ChengeOrderItemStatusResultDto>> Handle(ChengeOrderItemStatusCommand request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAllOrders();

            //if (!orders.Any())
            //    return Result.Fail("Orders not found");

            var orderItem = orders
                .SelectMany(o => o.OrderItems)
                .FirstOrDefault(oi => oi.OrderItemId == request.OrderItemId);

            if (orderItem == null)
                return Result.Fail("Order item not found");

            var statusResult = OrderItemStatus.Create(request.Status);

            if (statusResult.IsFailed)
                return CustomResultHelper.ToResul(statusResult);

            var newStatus = statusResult.Value;

            Result result = newStatus.Value switch
            {
                nameof(OrderItemStatus.Waiting) => orderItem.MarkAsWaiting(),
                nameof(OrderItemStatus.Paid) => orderItem.MarkAsPaid(),
                nameof(OrderItemStatus.Failed) => orderItem.MarkAsFailed(),
                nameof(OrderItemStatus.PickedUp) => orderItem.MarkAsPickedUp(),
                nameof(OrderItemStatus.Delivered) => orderItem.MarkAsDelivered(),
                nameof(OrderItemStatus.Cooked) => orderItem.MarkAsCooked(),
                nameof(OrderItemStatus.InWork) => orderItem.MarkAsInWork(),
                _ => Result.Fail($"Unhandled status value: {newStatus.Value}")
            };

            if (result.IsFailed)
                return result;

            await orderRepository.SaveChangesAsync();

            return new ChengeOrderItemStatusResultDto();
        }
    }
}
