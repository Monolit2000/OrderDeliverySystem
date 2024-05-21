using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Modules.Payments.Payment.Model;
using OrderDeliverySystem.Payments.Application.Payment.GetPaymentUrl;
using OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing;

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
        public async Task<IActionResult> GetPaymentUrl()
        {
            var result = await _mediator.Send(new GetPaymentUrlCommand());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }

            return Ok(result.Value);
        }

        [HttpGet("LiqPayCallback")]
        public async Task<IActionResult> LiqPayCallback(LiqPayCallbackModel request)
        {
            var result = await _mediator.Send(new CallbacProcessingCommand(request.data, request.signature));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }

            return Ok(result.Value);
        }
    }
}
