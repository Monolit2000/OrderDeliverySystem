using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Notifications.Application.TelegramClient.SendNotification
{
  

    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly IConfiguration _configuration;

        public SendNotificationCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationRequest = new
            {
                ChatId = request.ChatId,
                Message = request.Message
            };

            HttpClient httpClientT = new HttpClient();  

            HttpResponseMessage response = await httpClientT.PostAsJsonAsync(_configuration["NotificationServiceUrl"], notificationRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error sending notification: {response.StatusCode} - {errorContent}");
            }
       
        }
    }
    
}
