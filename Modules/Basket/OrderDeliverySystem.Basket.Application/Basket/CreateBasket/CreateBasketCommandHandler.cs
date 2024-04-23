using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.UpdateBaske;
using OrderDeliverySystem.Basket.Domain.Baskets;

namespace OrderDeliverySystem.Basket.Application.Basket.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, CreateBasketResult>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketCommandHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<CreateBasketResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = new CustomerBasket(
                request.BuyerId,
                request.BuyerChatId);

            await Console.Out.WriteLineAsync($"BasketId - {basket.BasketId}");

            //await Task.Delay(TimeSpan.FromSeconds(30));

            await _basketRepository.AddBasketAsync(basket);

            //var ExistBascket = await _basketRepository.GetBasketAsync(request.BuyerChatId);

            //await Console.Out.WriteLineAsync($"{ExistBascket.BuyerChatId} -> BasketId {ExistBascket.BasketId}");

            return new CreateBasketResult {BasketId = basket.BasketId};
        }
    }
}
