﻿using FluentResults;
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

            var basketToDelete = await _basketRepository.GetBasketByChatIdAsync(request.BuyerChatId);

            if (basketToDelete != null)
                await _basketRepository.DeleteBasketAsync(basketToDelete);

            var basket = new CustomerBasket(
                request.BuyerId,
                request.BuyerChatId);

            await _basketRepository.AddBasketAsync(basket);

           // await Console.Out.WriteLineAsync("Basket created");

            return new BasketDto { BasketId = basket.CustomerBasketId };

        }
    }
}
