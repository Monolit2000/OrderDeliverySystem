using Azure.Core;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using OrderDeliverySystem.Payments.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.IntegrationEventHandlers
{
    public class PaymentSuccessIntegrationEventHandler : INotificationHandler<PaymentSuccessIntegrationEvent>
    {
        public readonly IOrderRepository _orderRepository;

        public readonly ILogger<PaymentSuccessIntegrationEventHandler> _logger;

        public PaymentSuccessIntegrationEventHandler(
            IOrderRepository orderRepository,
            ILogger<PaymentSuccessIntegrationEventHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task Handle(PaymentSuccessIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(notification.OrderId);

            if (order == null)
            {
                _logger.LogError(
                    "IntegrationEvent Failed {@event}, {@DateTimeUtc}, Order not found", notification, DateTime.UtcNow);
                return;
            }

            order.SetPaidStatus();

            await _orderRepository.SaveChangesAsync();
        }
    }
}
