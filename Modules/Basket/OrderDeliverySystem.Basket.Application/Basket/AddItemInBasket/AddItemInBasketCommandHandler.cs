using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;


namespace OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket
{
    public class AddItemInBasketCommandHandler : IRequestHandler<AddItemInBasketCommand, Result<AddItemInBasketDto>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMediator _mediator;

        public AddItemInBasketCommandHandler(
            IBasketRepository userRepository,
            IMediator mediator)
        {
            _basketRepository = userRepository;
            _mediator = mediator;
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

            if (!basket.AddItem(basketItem))
                return Result.Fail($"Товар '{request.ProductName}' вже наявний у кошику");

            await _basketRepository.SaveChangesAsync();
        
            return new AddItemInBasketDto { Success = true };
        }
    }
}
