using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<CreateOrderDto>>
    {
        public readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<CreateOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Adderss);

            var order = new Order(request.BuyerId,request.FirstName, new Address(request.Adderss), request.Description);

            foreach (var item in request.OrderItems)
            {
                order.AddOrderItem(item.ItemId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
            }

            await _orderRepository.AddAsync(order);

            var createOrderDto = new CreateOrderDto(order.OrderId);

            return createOrderDto;
        }
    }
}
