﻿using Azure.Core;
using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.CreateBasket;
using OrderDeliverySystem.Basket.Application.Basket.GetBasket;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket
{
    public class AddItemInBasketCommandHandler : IRequestHandler<AddItemInBasketCommand, Result<AddItemInBasketDto>>
    {
        private readonly IBasketRepository _basketRepository;

        public AddItemInBasketCommandHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<Result<AddItemInBasketDto>> Handle(AddItemInBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketAsync(request.BuyerChatId);

            var basketItem = new BasketItem(
                    request.ProductId,
                    basket.BasketId,
                    request.ProductName,
                    request.UnitPrice,
                    request.Quantity = 1);

            basket.AddItem(basketItem);

            await _basketRepository.SaveChangesAsync();

            return new AddItemInBasketDto { Success = true };
        }
    }
}
