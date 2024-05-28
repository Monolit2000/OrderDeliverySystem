using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Application.TelegramClient.SendNotification
{
    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        public Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
