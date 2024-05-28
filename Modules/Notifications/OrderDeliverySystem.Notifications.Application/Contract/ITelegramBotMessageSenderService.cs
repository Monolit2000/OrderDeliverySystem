﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Application.Contract
{
    public interface ITelegramBotMessageSenderService
    {
        public Task SendMessage(string message);
    }
}
