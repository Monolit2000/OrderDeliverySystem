using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.SetShippedOrderStatus
{
    public class SetShippedOrderStatusCommandHandler : IRequestHandler<SetShippedOrderStatusCommand, Result<SetShippedOrderStatusDto>>
    {
        public readonly IOrderRepository _orderRepository;

        public SetShippedOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<Result<SetShippedOrderStatusDto>> Handle(SetShippedOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");

            var result = order.SetShippedStatus();

            if (result.IsFailed)
                return Result.Fail($"Cannot set status to Shipped because the order is not paid.");

            await _orderRepository.SaveChangesAsync();

            return new SetShippedOrderStatusDto()
            {
                OrderId = request.OrderId,
                OrderStatus = order.OrderStatus.Value
            };
        }
    }
}
