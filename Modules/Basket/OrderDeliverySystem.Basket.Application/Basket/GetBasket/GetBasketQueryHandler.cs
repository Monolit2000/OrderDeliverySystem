﻿using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, Result<BasketDto>>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasketQueryHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }
        public async Task<Result<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketByChatIdAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket does not exist");

            var basketDto = new BasketDto()
            {
                BasketId = basket.CustomerBasketId,

                BuyerId = basket.BuyerId,

                BasketItems = basket.Items
                    .Select(i => new BasketItemDto
                    {                  
                        ProductId = i.ProductId,
                        BasketItemId = i.BasketItemId,
                        ProductName = i.ProductName, 
                        UnitPrice = i.UnitPrice,
                        Quantity = i.Quantity,
                        Day = i.Day,    
                        IsDelivery = i.IsDelivery,
                        ProductImageUrl = i.ProductImageUrl,
                        DeliveryDateTime = i.DeliveryDateTime
                    }).ToList(),
            };

            return basketDto;
        }
    }
}
