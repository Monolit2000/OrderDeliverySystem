using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.CleanBasket
{
    public class CleanBasketCommandHandler : IRequestHandler<CleanBasketCommand, Result<CleanBasketDto>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMediator _mediator;

        public CleanBasketCommandHandler(
            IBasketRepository userRepository,
            IMediator mediator)
        {
            _basketRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<Result<CleanBasketDto>> Handle(CleanBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket dose not exist");

            basket.CleanBasket();

            await _basketRepository.SaveChangesAsync();

            return new CleanBasketDto() { Success = true };
        }
    }
}
