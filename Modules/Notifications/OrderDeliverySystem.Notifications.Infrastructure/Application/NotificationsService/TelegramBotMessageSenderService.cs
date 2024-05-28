using OrderDeliverySystem.Notifications.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Infrastructure.Application.NotificationsService
{
    public class TelegramBotMessageSenderService : ITelegramBotMessageSenderService
    {
        public Task SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
