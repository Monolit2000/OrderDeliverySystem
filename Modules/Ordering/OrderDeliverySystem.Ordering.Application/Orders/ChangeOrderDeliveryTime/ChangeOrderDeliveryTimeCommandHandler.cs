using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderDeliveryTime
{
    public class ChangeOrderDeliveryTimeCommandHandler : IRequestHandler<ChangeOrderDeliveryTimeCommand, Result<ChangeOrderDeliveryTimeResult>>
    {
        public readonly IOrderRepository _orderRepository;

        public ChangeOrderDeliveryTimeCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<ChangeOrderDeliveryTimeResult>> Handle( ChangeOrderDeliveryTimeCommand request,  CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");

            var result = order.ChangeDeliveryTime( request.OrderItmeId, request.NewDeliveriDetaTime);

            if (result.IsFailed)
                return result;

            return new ChangeOrderDeliveryTimeResult();
        }
    }
}
