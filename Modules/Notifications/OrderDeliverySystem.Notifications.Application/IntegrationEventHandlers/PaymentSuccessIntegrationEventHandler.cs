//using MediatR;
//using Microsoft.Extensions.Logging;
//using OrderDeliverySystem.Payments.IntegrationEvents;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OrderDeliverySystem.Notifications.Application.IntegrationEventHandlers
//{
//    public class PaymentSuccessIntegrationEventHandler : INotificationHandler<PaymentSuccessIntegrationEvent>
//    {

//        public readonly ILogger<PaymentSuccessIntegrationEventHandler> _logger;

//        public PaymentSuccessIntegrationEventHandler(
//            ILogger<PaymentSuccessIntegrationEventHandler> logger)
//        {
//            _logger = logger;
//        }

//        public async Task Handle(PaymentSuccessIntegrationEvent notification, CancellationToken cancellationToken)
//        {

//            if (order == null)
//            {
//                _logger.LogError(
//                    "IntegrationEvent Failed {@event}, {@DateTimeUtc}, Order not found", notification, DateTime.UtcNow);
//                return;
//            }

//            order.SetPaidStatus();

//            await _orderRepository.SaveChangesAsync();
//        }
//    }
//}
