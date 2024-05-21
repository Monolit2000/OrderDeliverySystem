using MediatR;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using OrderDeliverySystem.UserAccess.Domain.Users.DomainEvents;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;

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
           await _eventBus.PublishAsync(new ConsumerActivatedIntegretionEvent(
                notification.UserId,
                notification.PhoneNumber,
                notification.ChatId,
                notification.FirstName,
                notification.LastName,
                notification.Name));
        }
    }
}
