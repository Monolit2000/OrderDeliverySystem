using MediatR;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.UserAccess.Domain.Users.DomainEvents;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Authentication.DomainEventHandlers
{
    public class UserActivatedDomainEventHendler : INotificationHandler<UserActivatedDomainEvent>
    {

        private readonly IAsyncEventBus _eventBus;

        public UserActivatedDomainEventHendler(IAsyncEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(UserActivatedDomainEvent notification, CancellationToken cancellationToken)
        {
           await Console.Out.WriteLineAsync(notification.PhoneNumber);


           await _eventBus.PublishAsync(new CatalogItemAddIntegretionEvent(Guid.NewGuid(), DateTime.UtcNow));


           await _eventBus.PublishAsync(new ConsumerActivatedIntegretionEvent(
                notification.UserId,
                notification.PhoneNumber,
                notification.ChatId,
                notification.FirstName,
                notification.LastName,
                notification.Name,
                notification.Id,
                notification.OccurredOn));

        }
    }
}
