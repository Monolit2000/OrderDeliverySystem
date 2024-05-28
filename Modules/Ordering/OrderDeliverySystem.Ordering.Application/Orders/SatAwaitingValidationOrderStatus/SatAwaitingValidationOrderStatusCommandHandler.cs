using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.SatAwaitingValidationOrderStatus
{
    public class SatAwaitingValidationOrderStatusCommandHandler : IRequestHandler<SatAwaitingValidationOrderStatusCommand, Result<SatAwaitingValidationOrderStatusDto>>
    {
        public readonly IOrderRepository _orderRepository;

        public SatAwaitingValidationOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<SatAwaitingValidationOrderStatusDto>> Handle(SatAwaitingValidationOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");

            var setStatusResult = order.SetAwaitingValidationStatus();

            if (setStatusResult.IsFailed)
                return setStatusResult;

            await _orderRepository.SaveChangesAsync();

            return new SatAwaitingValidationOrderStatusDto()
            {
                OrderId = request.OrderId,
                OrderStatus = order.OrderStatus.Value
            };
        }
    }
}
