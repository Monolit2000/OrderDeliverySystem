using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket;
using OrderDeliverySystem.Basket.Application.Basket.CleanBasket;
using OrderDeliverySystem.Basket.Application.Basket.CreateBasket;
using OrderDeliverySystem.Basket.Application.Basket.DeleteBasketItem;
using OrderDeliverySystem.Basket.Application.Basket.GetBasket;
using OrderDeliverySystem.Basket.Application.Basket.UpdateBaske;
using OrderDeliverySystem.API.Modules.Base;

namespace OrderDeliverySystem.API.Modules.Baskets.Basket
{
    [Route("api/Basket/Basket")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("GetBasket")]
        public async Task<IActionResult> GetBasket(GetBasketQuery getBasketQuery)
        {
            return HandleResult(await _mediator.Send(getBasketQuery));
        }


        [HttpPost("CreateBasket")]
        public async Task<IActionResult> CreateBasket(AddBasketRequest addBasketRequest)
        {
            return HandleResult(await _mediator.Send(new CreateBasketCommand(Guid.NewGuid(), addBasketRequest.BuyerChatId)));
        }

        [HttpPost("AddItemInBasket")]
        public async Task<IActionResult> AddItemInBasket(AddItemInBasketCommand addItemInBasket)
        {
            return HandleResult( await _mediator.Send(addItemInBasket));
        }


        [HttpPost("DeleteBasketItem")]
        public async Task<IActionResult> DeleteBasketItem(DeleteBasketItemCommand deleteBasketItemCommand)
        {
            return HandleResult(await _mediator.Send(deleteBasketItemCommand));
        }


        [HttpPost("CleanBasket")]
        public async Task<IActionResult> CleanBasket(CleanBasketCommand cleanBasketCommand)
        {
            return HandleResult(await _mediator.Send(cleanBasketCommand)); 
        }


        [HttpPost("UpdateBasket")]
        public async Task<IActionResult> UpdateBasket(UpdateBasketCommand updateBasketCommand)
        {
            return HandleResult(await _mediator.Send(updateBasketCommand));
        }
    }
}
