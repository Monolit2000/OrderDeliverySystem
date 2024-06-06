using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;


namespace OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket
{
    public class AddItemInBasketCommandHandler : IRequestHandler<AddItemInBasketCommand, Result<AddItemInBasketDto>>
    {
        private readonly IBasketRepository _basketRepository;

        public AddItemInBasketCommandHandler(
            IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<Result<AddItemInBasketDto>> Handle(AddItemInBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketByChatIdAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket dose not exist");

            var basketItem = new BasketItem(
                    request.ProductId,
                    request.ProductName,
                    request.UnitPrice,
                    request.Day,
                    request.ProductImageUrl,
                    request.Quantity);

            var addItemrResult = basket.AddItem(basketItem);

            if(addItemrResult.IsFailed)
                return addItemrResult;

            await _basketRepository.SaveChangesAsync();
        
            return new AddItemInBasketDto { Success = true };
        }
    }
}
