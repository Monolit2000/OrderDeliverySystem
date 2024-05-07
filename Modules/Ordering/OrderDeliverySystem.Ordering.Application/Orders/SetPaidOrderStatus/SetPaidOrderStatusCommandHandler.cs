using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus
{
    public class SetPaidOrderStatusCommandHandler : IRequestHandler<SetPaidOrderStatusCommand, Result<SetPaidOrderStatusDto>>
    {
        public readonly IOrderRepository _orderRepository;

        public SetPaidOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<Result<SetPaidOrderStatusDto>> Handle(SetPaidOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");

            order.SetPaidStatus();

            await _orderRepository.SaveChangesAsync();

            return new SetPaidOrderStatusDto() 
            { 
                OrderId = request.OrderId,
                OrderStatus = order.OrderStatus.Value
            };
        }
    }
}
