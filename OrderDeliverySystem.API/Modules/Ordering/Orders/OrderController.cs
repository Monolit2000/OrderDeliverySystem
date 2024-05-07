using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem;
using OrderDeliverySystem.Ordering.Application.Orders.CancelOrder;
using OrderDeliverySystem.Ordering.Application.Orders.CreateOrder;
using OrderDeliverySystem.Ordering.Application.Orders.GetOllOrdersByBuyerChatId;
using OrderDeliverySystem.Ordering.Application.Orders.SatAwaitingValidationOrderStatus;
using OrderDeliverySystem.Ordering.Application.Orders.SerSubmittedOrderStatus;
using OrderDeliverySystem.Ordering.Application.Orders.SetPaidOrderStatus;
using OrderDeliverySystem.Ordering.Application.Orders.SetShippedOrderStatus;

namespace OrderDeliverySystem.API.Modules.Ordering.Orders
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            var result = await _mediator.Send(createOrderCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(CancelOrderCommand cancelOrderCommand)
        {
            var result = await _mediator.Send(cancelOrderCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost("GetOllOrdersByBuyerChatId")]
        public async Task<IActionResult> GetOllOrdersByBuyerChatId(GetOllOrdersByBuyerChatIdQuery getOllOrdersByBuyerChatIdQuery)
        {
            var result = await _mediator.Send(getOllOrdersByBuyerChatIdQuery);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }


        [HttpPost("SetPaidOrderStatus")]
        public async Task<IActionResult> SetPaidOrderStatus(SetPaidOrderStatusCommand setPaidOrderStatusCommand)
        {
            var result = await _mediator.Send(setPaidOrderStatusCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost("SetShippedOrderStatus")]
        public async Task<IActionResult> SetPaidOrderStatus(SetShippedOrderStatusCommand setShippedOrderStatusCommand)
        {
            var result = await _mediator.Send(setShippedOrderStatusCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost("SatAwaitingValidationOrderStatus")]
        public async Task<IActionResult> SatAwaitingValidationOrderStatus(SatAwaitingValidationOrderStatusCommand satAwaitingValidationOrderStatusCommand)
        {
            var result = await _mediator.Send(satAwaitingValidationOrderStatusCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }
        
    }
}