using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Modules.Base;
using OrderDeliverySystem.API.Modules.Payments.Payment.Model;
using OrderDeliverySystem.Payments.Application.PaymentProcessor.CallbacProcessing;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentStatus;
using OrderDeliverySystem.Payments.Application.Payments.GetPaymentUrl;

namespace OrderDeliverySystem.API.Modules.Payments.Payment
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetPaymentUrl")]
        public async Task<IActionResult> GetPaymentUrl([FromQuery] GetPaymentUrlCommand getPaymentUrlCommand)
        {
            return HandleResult(await _mediator.Send(getPaymentUrlCommand));
        }


        [HttpPost("LiqPayCallback")]
        public async Task<IActionResult> LiqPayCallback([FromForm] LiqPayCallbackModel request)
        {
            return HandleResult(await _mediator.Send(new CallbacProcessingCommand(request.data, request.signature)));
        }


        [HttpPost("GetPaymentStatus")]
        public async Task<IActionResult> GetPaymentStatus(GetPaymentStatusQuery getPaymentStatusQuery)
        {
            return HandleResult(await _mediator.Send(getPaymentStatusQuery));
        }
    }
}
