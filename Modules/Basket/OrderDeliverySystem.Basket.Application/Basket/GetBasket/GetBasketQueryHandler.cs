using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, Result<BasketDto>>
    {
        private readonly IBasketRepository _basketRepository;

        private readonly IDistributedCache _cache;

        public GetBasketQueryHandler(
            IBasketRepository userRepository,
            IDistributedCache cache)
        {
            _basketRepository = userRepository;
            _cache = cache;
        }
        public async Task<Result<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            //string key = $"baskets-{request.BuyerChatId}";

            //var caheValue = await _cache.GetStringAsync(key, cancellationToken);

            //CustomerBasket? customerBasket;
            //if (!string.IsNullOrWhiteSpace(caheValue))
            //{
            //    customerBasket = JsonSerializer.Deserialize<CustomerBasket>(caheValue);

            //    if(customerBasket is not null)
            //    {
            //        Result.Ok(customerBasket);
            //    }
            //}

            var basket = await _basketRepository.GetByChatIdAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket does not exist");

           // await _cache.SetStringAsync(key, JsonSerializer.Serialize(basket));   



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
