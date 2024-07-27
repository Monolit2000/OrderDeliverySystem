using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OrderDeliverySystem.Ordering.Domain.Orders;
using OrderDeliverySystem.Payments.Api;
using OrderDeliverySystem.Payments.Api.GetCheckoutUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.CreateOrder
{
    public class CreateOrderCommandHandler(
        IOrderRepository _orderRepository, 
        IPaymentsApi _paymentsApi) : IRequestHandler<CreateOrderCommand, Result<CreateOrderDto>>
    {
        public async Task<Result<CreateOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.CreateNew(
                request.UserId,
                request.Adderss);

            foreach (var item in request.OrderItems)
            {
               var result = order.AddOrderItem(
                    item.ItemId,
                    item.ProductName,
                    item.UnitPrice,
                    item.Discount,
                    item.PictureUrl,
                    item.IsDelivery,
                    item.DeliveryDateTime,
                    request.Adderss,
                    item.Units);

                if (result.IsFailed)
                    return result;
            }

            var addOrderTask = _orderRepository.AddAsync(order);

            var checkoutUrlResultTask = _paymentsApi.GetCheckoutUrl(new GetCheckoutUrlRequest
            {
                UserId = order.BuyerId,
                OrderId = order.Id.Value,
                Amount = order.GetAmount(),
            });

            await Task.WhenAll(addOrderTask, checkoutUrlResultTask);

            if (checkoutUrlResultTask.Result.IsFailed)
                return Result.Fail<CreateOrderDto>(checkoutUrlResultTask.Result.Errors);

            var getCheckoutUrlResponce = checkoutUrlResultTask.Result.Value;

            var createOrderDto = new CreateOrderDto(
                order.Id.Value, getCheckoutUrlResponce.CheckoutUrl);

            return Result.Ok(createOrderDto);
        }
    }
}
