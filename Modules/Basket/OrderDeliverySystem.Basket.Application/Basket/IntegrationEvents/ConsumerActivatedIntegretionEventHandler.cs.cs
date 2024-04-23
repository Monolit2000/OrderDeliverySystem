using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.CreateBasket;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.IntegrationEvents
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
            await Console.Out.WriteLineAsync("ConsumerActivatedIntegretionEventHandler Basket");

            var test = await _mediator.Send(new CreateBasketCommand(notification.UserId, notification.ChatId));

            await Console.Out.WriteLineAsync("ETSTESTESTSETSETSETSESTESETSET");
        }
    }
}
