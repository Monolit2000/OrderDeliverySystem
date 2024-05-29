using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Ordering.Application.Orders.CancelOrder;
using OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderStaus;
using OrderDeliverySystem.Ordering.Application.Orders.CreateOrder;
using OrderDeliverySystem.Ordering.Application.Orders.GetOllOrders;
using OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId;
using OrderDeliverySystem.Ordering.Application.Orders.SatAwaitingValidationOrderStatus;
using OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus;
using OrderDeliverySystem.Ordering.Application.Orders.SetShippedOrderStatus;
using OrderDeliverySystem.API.Modules.Base;

namespace OrderDeliverySystem.API.Modules.Ordering.Orders
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            return HandleResult(await _mediator.Send(createOrderCommand));
        }


        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(CancelOrderCommand cancelOrderCommand)
        {
            return HandleResult(await _mediator.Send(cancelOrderCommand));
        }


        [HttpPost("GetOllOrdersByBuyerChatId")]
        public async Task<IActionResult> GetOllOrdersByBuyerChatId(GetOllOrdersByBuyerChatIdQuery getOllOrdersByBuyerChatIdQuery)
        {
            return HandleResult(await _mediator.Send(getOllOrdersByBuyerChatIdQuery));
        }


        [HttpGet("GetOllOrders")]
        public async Task<IActionResult> GetOllOrdersByBuyerChatId()
        {
            return HandleResult(await _mediator.Send(new GetOllOrdersQuerie()));
        }


        [HttpPost("SetPaidOrderStatus")]
        public async Task<IActionResult> SetPaidOrderStatus(SetPaidOrderStatusCommand setPaidOrderStatusCommand)
        {
            return HandleResult(await _mediator.Send(setPaidOrderStatusCommand));
        }


        [HttpPost("SetShippedOrderStatus")]
        public async Task<IActionResult> SetPaidOrderStatus(SetShippedOrderStatusCommand setShippedOrderStatusCommand)
        {
            return HandleResult(await _mediator.Send(setShippedOrderStatusCommand));
        }


        [HttpPost("SatAwaitingValidationOrderStatus")]
        public async Task<IActionResult> SatAwaitingValidationOrderStatus(SatAwaitingValidationOrderStatusCommand satAwaitingValidationOrderStatusCommand)
        {
            return HandleResult(await _mediator.Send(satAwaitingValidationOrderStatusCommand));
        }


        [HttpPost("ChangeOrderStatus")]
        public async Task<IActionResult> SatAwaitingValidationOrderStatus(ChangeOrderStatusCommand changeOrderStatusCommand)
        {
            return HandleResultWithReasonsAsStrArray(await _mediator.Send(changeOrderStatusCommand));
        }

    }
}