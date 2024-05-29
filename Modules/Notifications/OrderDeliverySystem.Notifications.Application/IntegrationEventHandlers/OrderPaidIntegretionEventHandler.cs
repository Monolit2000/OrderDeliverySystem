using MediatR;
using OrderDeliverySystem.Notifications.Application.TelegramClient.SendNotification;
using OrderDeliverySystem.Ordering.IntegrationEvents;
using OrderDeliverySystem.UserAccess.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Application.IntegrationEventHandlers
{
    public class OrderPaidIntegretionEventHandler : INotificationHandler<OrderPaidIntegretionEvent>
    {
        private readonly IMediator _mediator;

        private readonly IUserAccessApi _userAccessApi; 

       public OrderPaidIntegretionEventHandler(IMediator mediator, IUserAccessApi userAccessApi)
        {
            _mediator = mediator;
            _userAccessApi = userAccessApi; 
        }

        public async Task Handle(OrderPaidIntegretionEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userAccessApi.GetUserAsync(notification.BuyerId); 

            await _mediator.Send(new SendNotificationCommand
            {
                ChatId = user.UserChatId,
                Message = $"Замовлення '{notification.OrderId}' успішно оплачено"
            });
        }
    }
}
