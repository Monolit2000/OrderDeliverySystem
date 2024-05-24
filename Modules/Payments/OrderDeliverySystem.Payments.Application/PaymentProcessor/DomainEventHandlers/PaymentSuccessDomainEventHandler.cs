using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.Payments.Domain.PaymentAggregate.DomainEvents;
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

        public PaymentSuccessDomainEventHandler(IAsyncEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(PaymentSuccessDomainEvent notification, CancellationToken cancellationToken)
        {

            //await _eventBus.PublishAsync(new PaymentFailedIntegretionEvent(

            //     notification.OccurredOn));

        }
    }
}
