using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Modules.Payments.Payment.Model;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentStatus;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl;

namespace OrderDeliverySystem.API.Modules.Payments.Payment
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPaymentUrl")]
        public async Task<IActionResult> GetPaymentUrl([FromQuery] GetPaymentUrlCommand getPaymentUrlCommand)
        {
            var result = await _mediator.Send(getPaymentUrlCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }

            return Ok(result.Value);
        }

        [HttpPost("LiqPayCallback")]
        public async Task<IActionResult> LiqPayCallback([FromForm] LiqPayCallbackModel request)
        {
            var result = await _mediator.Send(new CallbacProcessingCommand(request.data, request.signature));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }
            return Ok(result.Value);
        }

        [HttpPost("GetPaymentStatus")]
        public async Task<IActionResult> GetPaymentStatus(GetPaymentStatusQuery getPaymentStatusQuery)
        {
            var result = await _mediator.Send(getPaymentStatusQuery);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }
            return Ok(result.Value);
        }
    }
}
