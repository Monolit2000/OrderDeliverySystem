using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Notifications.Application.TelegramClient.SendNotification;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentStatus;

namespace OrderDeliverySystem.API.Modules.Notifications
{
    [Route("api/Notification")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendNotification(SendNotificationCommand sendNotificationCommand)
        {
            try
            {
                await _mediator.Send(sendNotificationCommand);
                return Ok(new { message = "Notification sent successfully" });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { error = "Failed to send notification", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred", details = ex.Message });
            }
        }
    }
}
