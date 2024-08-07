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
            var basket = await _basketRepository.GetByChatIdAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket dose not exist");

            var basketItem = new BasketItem(
                    request.ProductId,
                    request.ProductName,
                    request.UnitPrice,
                    request.Day,
                    request.ProductImageUrl,
                    request.Description,
                    request.Quantity);

            OptionalItem newOptionalItem = new();

            if (request.IsAdded == true && 
                request.OptionalItemName != null &&
                request.OptionalItemDescription != null &&
                request.OptionalItemPrice != default)
            {
                newOptionalItem = new OptionalItem(
                request.IsAdded == true,
                request.OptionalItemName,
                request.OptionalItemDescription,
                request.OptionalItemPrice);
            }

            basketItem.AddOptionalItem(newOptionalItem);


            var addItemrResult = basket.AddItem(basketItem);

            if(addItemrResult.IsFailed)
                return addItemrResult;

            await _basketRepository.SaveChangesAsync();
        
            return new AddItemInBasketDto { Success = true };
        }
    }
}
