using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket;
using OrderDeliverySystem.Basket.Application.Basket.CreateBasket;
using OrderDeliverySystem.Basket.Application.Basket.GetBasket;
using OrderDeliverySystem.Catalog.Application.Establishments.GetOllEstablishment;

namespace OrderDeliverySystem.API.Modules.Baskets.Basket
{
    [Route("api/Basket/Basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket(GetBasketRequest getBasketRequest)
        {
            var result = await _mediator.Send(new GetBasketQuery());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost("CreateBasket")]
        public async Task<IActionResult> CreateBasket(AddBasketRequest addBasketRequest)
        {
            var result = await _mediator.Send(new CreateBasketCommand(Guid.NewGuid(), addBasketRequest.BuyerChatId));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }


        [HttpPut("UpdateBasket")]
        public async Task<IActionResult> UpdateBasket(UpdateBasketRequest getBasketRequest)
        {
            var result = await _mediator.Send(new GetBasketQuery());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }


        [HttpPost("AddItemInBasket")]
        public async Task<IActionResult> AddItemInBasket(AddItemInBasketCommand addItemInBasket)
        {
            var result = await _mediator.Send(addItemInBasket);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

    }
}
