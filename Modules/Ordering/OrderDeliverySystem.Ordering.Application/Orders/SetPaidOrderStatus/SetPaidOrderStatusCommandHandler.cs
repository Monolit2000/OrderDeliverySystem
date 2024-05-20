using Azure;
using Azure.Core;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Ordering.Application.Behaviors;
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
        private readonly ILogger<SetPaidOrderStatusCommandHandler> _logger;
        public SetPaidOrderStatusCommandHandler(IOrderRepository orderRepository, ILogger<SetPaidOrderStatusCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }


        public async Task<Result<SetPaidOrderStatusDto>> Handle(SetPaidOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");

            if (order.SetPaidStatus().IsFailed)
                return Result.Fail("Cannot set the order status to Paid because it is already Shipped.");
            

            await _orderRepository.SaveChangesAsync();

            return new SetPaidOrderStatusDto() 
            { 
                OrderId = request.OrderId,
                OrderStatus = order.OrderStatus.Value
            };
        }
    }
}
