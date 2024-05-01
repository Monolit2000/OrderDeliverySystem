using MediatR;
using OrderDeliverySystem.Ordering.Application.Buyers.AddBuyer;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Buyers.IntegrationEventsHandlers
{
    public class ConsumerActivatedIntegretionEventHandler : INotificationHandler<ConsumerActivatedIntegretionEvent>
    {
        private readonly IMediator _mediator;

        public ConsumerActivatedIntegretionEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(ConsumerActivatedIntegretionEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddBuyerCommand(
                notification.UserId, 
                notification.PhoneNumber,
                notification.ChatId, 
                notification.FirstName,
                notification.LastName, 
                notification.Name));
        }
    }
}
