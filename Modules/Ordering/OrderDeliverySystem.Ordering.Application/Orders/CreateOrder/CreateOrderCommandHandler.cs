using FluentResults;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using OrderDeliverySystem.Payments.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<CreateOrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentsApi _paymentsApi;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IPaymentsApi paymentsApi)
        {
            _orderRepository = orderRepository;
            _paymentsApi = paymentsApi;
        }

        public async Task<Result<CreateOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(
                request.UserId,
                request.Adderss);

            foreach (var item in request.OrderItems)
            {
                order.AddOrderItem(item.ItemId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
            }

            var addOrderTask = _orderRepository.AddAsync(order);

            var getCheckoutUrlResultTask = _paymentsApi.GetCheckoutUrl(
            new GetCheckoutUrlRequest 
            {
                UserId = order.BuyerId, OrderId = order.OrderId, Amount = order.Amount
            });

            await Task.WhenAll(addOrderTask, getCheckoutUrlResultTask);

            if (getCheckoutUrlResultTask.Result.IsFailed)
            {
                return Result.Fail<CreateOrderDto>(getCheckoutUrlResultTask.Result.Errors);
            }

            var getCheckoutUrlResponce = getCheckoutUrlResultTask.Result.Value;
            var createOrderDto = new CreateOrderDto(order.OrderId, getCheckoutUrlResponce.CheckoutUrl);

            return Result.Ok(createOrderDto);
        }
    }
}
