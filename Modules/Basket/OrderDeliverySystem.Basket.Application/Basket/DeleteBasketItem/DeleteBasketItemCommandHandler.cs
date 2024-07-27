using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;

namespace OrderDeliverySystem.Basket.Application.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand, Result<DeleteBasketItemDto>>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketItemCommandHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<Result<DeleteBasketItemDto>> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketByChatIdAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket dose not exist");

            var result = basket.RemoveItem(request.BasketItemId);

            if (result.IsFailed)
                return Result.Fail("Item not exist");

            await _basketRepository.SaveChangesAsync();   

            return new DeleteBasketItemDto { Success = true};
        }
    }
}
