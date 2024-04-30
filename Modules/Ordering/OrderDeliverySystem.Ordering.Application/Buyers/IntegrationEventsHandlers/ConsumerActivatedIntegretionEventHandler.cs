using MediatR;
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
        public readonly IBuyerRepository _buyerRepository;

        public ConsumerActivatedIntegretionEventHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task Handle(ConsumerActivatedIntegretionEvent notification, CancellationToken cancellationToken)
        {
            var buyer = new Buyer(notification.UserId, notification.ChatId, notification.Name, notification.PhoneNumber);

            await Console.Out.WriteLineAsync(buyer.Name);
        }
    }
}
