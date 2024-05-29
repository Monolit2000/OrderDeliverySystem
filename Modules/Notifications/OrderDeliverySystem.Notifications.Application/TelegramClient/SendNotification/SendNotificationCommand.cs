using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Application.TelegramClient.SendNotification
{
    public class SendNotificationCommand : IRequest
    {
        public long ChatId { get; set; }

        public string Message { get; set; }
    }
}
