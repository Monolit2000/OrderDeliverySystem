using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System.Reflection.Metadata.Ecma335;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderStaus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand, Result<ChangeOrderStatusDto>>
    {
        public readonly IOrderRepository _orderRepository;

        public ChangeOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<ChangeOrderStatusDto>> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");


            Result result = request.Status switch
            {
                "Submitted" => order.SetSubmittedStatus(),
                "Paid" => order.SetPaidStatus(),
                "Shipped" => order.SetShippedStatus(),
                "Cancelled" => order.SetCancelledStatus(),
                //"PaidFaild" => 
                _ => Result.Fail("Unprocessed status")
            };

            if (result.IsFailed)
                return result;

            await _orderRepository.SaveChangesAsync();

            return new ChangeOrderStatusDto 
            { 
                OrderId = order.OrderId, 
                OrderStatus = order.OrderStatus.Value 
            };
        }
    }
}
