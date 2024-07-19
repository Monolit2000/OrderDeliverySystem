using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Ordering.Domain.Orders;


namespace OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus
{
    public class SetPaidOrderStatusCommandHandler : IRequestHandler<SetPaidOrderStatusCommand, Result<SetPaidOrderStatusDto>>
    {
        private readonly IOrderRepository _orderRepository;
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

            var result = order.SetPaidStatus();
            if (!result.IsSuccess)
                return result;
            
            await _orderRepository.SaveChangesAsync();

            return new SetPaidOrderStatusDto() 
            { 
                OrderId = request.OrderId,
                OrderStatus = order.OrderStatus.Value
            };
        }
    }
}
