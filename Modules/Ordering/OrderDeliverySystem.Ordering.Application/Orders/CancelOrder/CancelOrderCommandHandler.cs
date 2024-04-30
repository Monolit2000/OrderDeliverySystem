using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OrderDeliverySystem.Ordering.Application.Orders.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Result<CancelOrderDto>>
    {
        public readonly IOrderRepository _orderRepository;

        public CancelOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<CancelOrderDto>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetAsync(request.OrderId);

            if (orderToUpdate == null)
            {
                return Result.Fail("Order not found"); 
            }

            orderToUpdate.SetCancelledStatus();

            await _orderRepository.SaveChangesAsync();

            return new CancelOrderDto(orderToUpdate.OrderId, orderToUpdate.OrderStatus);
        }
    }
}
