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
using OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderDeliveryTime;
using OrderDeliverySystem.Ordering.Application.Orders.ChangeDeliveryOptions;
using OrderDeliverySystem.Ordering.Application.Orders.GetOrderItemByDay;
using OrderDeliverySystem.Ordering.Application.Orders.GetAllOrderItemByDayRange;
using OrderDeliverySystem.Ordering.Application.Orders.ChengeOrderItemStatus;

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


        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetOllOrdersByBuyerChatId()
        {
            return HandleResult(await _mediator.Send(new GetOllOrdersQuerie()));
        }


        [HttpPost("GetAllOrderItemByDay")]
        public async Task<IActionResult> GetAllOrderItemByDay(GetAllOrderItemByDayQuery getAllOrderItemByDayQuery)
        {
            return HandleResult(await _mediator.Send( getAllOrderItemByDayQuery));
        }

        [HttpPost("GetAllOrderItemsByDayRange")]
        public async Task<IActionResult> GetAllOrderItemsByDayRange(GetAllOrderItemByDayRangeQuery getAllOrderItemByDayRangeQuery)
        {
            return HandleResultWithReasonsAsStrArray(await _mediator.Send(getAllOrderItemByDayRangeQuery));
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
        public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusCommand changeOrderStatusCommand)
        {
            return HandleResultWithReasonsAsStrArray(await _mediator.Send(changeOrderStatusCommand));
        }


    


        [HttpPost("ChengeOrderItemStatus")]
        public async Task<IActionResult> ChengeOrderItemStatus(ChengeOrderItemStatusCommand chengeOrderItemStatusCommand)
        {
            return HandleResultWithReasonsAsStrArray(await _mediator.Send(chengeOrderItemStatusCommand));
        }


        [HttpPost("ChengeOrderItemStatusTest")]
        public async Task<IActionResult> ChengeOrderItemSdsftatus(ChengeOrderItemStatusCommand chengeOrderItemStatusCommand)
        {
            return HandleResult(await _mediator.Send(chengeOrderItemStatusCommand));
        }




        [HttpPost("ChangeOrderDeliveryTime")]
        public async Task<IActionResult> ChangeOrderDeliveryTime(ChangeOrderDeliveryTimeCommand changeOrderDeliveryTimeCommand)
        {
            return HandleResultWithReasonsAsStrArray(await _mediator.Send(changeOrderDeliveryTimeCommand));
        }

        [HttpPost("ChangeDeliveryOptions")]
        public async Task<IActionResult> ChangeDeliveryOptions(ChangeDeliveryOptionsCommand changeDeliveryOptionsCommand)
        {
            return HandleResultWithReasonsAsStrArray(await _mediator.Send(changeDeliveryOptionsCommand));
        }
    }
}