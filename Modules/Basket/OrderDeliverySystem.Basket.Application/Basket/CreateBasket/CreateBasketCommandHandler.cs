using MediatR;
using Microsoft.EntityFrameworkCore;
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
                request.BuyerId);

            await Console.Out.WriteLineAsync($"BasketId - {basket.BasketId}");

            await _basketRepository.AddBasketAsync(basket);

            await _basketRepository.SaveChangesAsync();

            return new CreateBasketResult { BasketId = basket.BasketId };

        }
    }
}
