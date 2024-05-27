using Azure.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate.DomainEvents;
using OrderDeliverySystem.Payments.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.PaymentProcessor.DomainEventHandlers
{
    public class PaymentSuccessDomainEventHandler : INotificationHandler<PaymentSuccessDomainEvent>
    {
        private readonly IAsyncEventBus _eventBus;
        private readonly ILogger<PaymentSuccessDomainEventHandler> _logger;
        public PaymentSuccessDomainEventHandler(
            IAsyncEventBus eventBus, 
            ILogger<PaymentSuccessDomainEventHandler> logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task Handle(PaymentSuccessDomainEvent notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation(
                 "Starting request {@RequestName}, {@DateTimeUtc}",
                 typeof(PaymentSuccessDomainEvent).Name,
                 DateTime.UtcNow);

            await _eventBus.PublishAsync(new PaymentSuccessIntegrationEvent(
                notification.PaymentId,
                notification.OrderId));
        }
    }
}
