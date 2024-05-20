using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Payments.Application.Payment.GetPaymentUrl;

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
        public async Task<IActionResult> SatAwaitingValidationOrderStatus()
        {
            var result = await _mediator.Send(new GetPaymentUrlCommand());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }

            return Ok(result.Value);
        }
    }
}
