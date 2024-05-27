using MediatR;
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
    public class PaymentFailedDomainEventHandler : INotificationHandler<PaymentStatusChangedDomainEvent>
    {
        private readonly IAsyncEventBus _eventBus;

        public PaymentFailedDomainEventHandler(IAsyncEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(PaymentStatusChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            //await _eventBus.PublishAsync(new PaymentSuccessIntegrationEvent(
            //    notification.OrderId,
            //    notification.PaymentId));
        }
    }
}
