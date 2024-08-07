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

            var statusResult = OrderItemStatus.Create(request.NewStatus);

            if (statusResult.IsFailed)
                return CustomResultHelper.ToResult(statusResult);

            var newStatus = statusResult.Value;

            //change status 
            var changeStatusResult = orderItem.ChangeStatus(newStatus);

            if (changeStatusResult.IsFailed)
                return changeStatusResult;

            await orderRepository.SaveChangesAsync();

            return new ChengeOrderItemStatusResultDto();
        }
    }
}
