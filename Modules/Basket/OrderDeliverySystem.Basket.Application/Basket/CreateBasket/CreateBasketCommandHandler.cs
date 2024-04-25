using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Application.Basket.GetBasket;
using OrderDeliverySystem.Basket.Application.Basket.UpdateBaske;
using OrderDeliverySystem.Basket.Domain.Baskets;

namespace OrderDeliverySystem.Basket.Application.Basket.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Result<BasketDto>>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBasketCommandHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<Result<BasketDto>> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = new CustomerBasket(
                request.BuyerId);

            await _basketRepository.AddBasketAsync(basket);

            await _basketRepository.SaveChangesAsync();

            return new BasketDto { BasketId = basket.BasketId };

        }
    }
}
