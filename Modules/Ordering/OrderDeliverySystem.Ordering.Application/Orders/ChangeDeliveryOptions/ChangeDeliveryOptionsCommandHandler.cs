using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderDeliveryTime;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeDeliveryOptions
{
    public class ChangeDeliveryOptionsCommandHandler : IRequestHandler<ChangeDeliveryOptionsCommand, Result<ChangeDeliveryOptionsResult>>
    {


        public readonly IOrderRepository _orderRepository;

        public ChangeDeliveryOptionsCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<ChangeDeliveryOptionsResult>> Handle(ChangeDeliveryOptionsCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.OrderId);

            if (order == null)
                return Result.Fail("Order not found");

            var results = new List<Result>
            {
                request.NewDeliveriDetaTime != default ? order.ChangeDeliveryTime(request.OrderItmeId, request.NewDeliveriDetaTime) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.NewAddress) ? order.ChangeDeliveryAddress(request.OrderItmeId, request.NewAddress) : Result.Ok(),
            };

            var combinedResult = CombineResults(results);

            if (combinedResult.IsFailed)
                return Result.Fail(combinedResult.Errors.First());

            await _orderRepository.SaveChangesAsync();

            return new ChangeDeliveryOptionsResult();
        }


        private Result CombineResults(IEnumerable<Result> results)
        {
            foreach (var result in results)
            {
                if (result.IsFailed)
                    return result;
            }
            return Result.Ok();
        }

    }
}
