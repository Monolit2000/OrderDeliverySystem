﻿using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, Result<UpdateBasketResult>>
    {

        private readonly IBasketRepository _busketRepository;

        public UpdateBasketCommandHandler(IBasketRepository userRepository)
        {
            _busketRepository = userRepository;
        }

        public async Task<Result<UpdateBasketResult>> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _busketRepository.GetBasketByBuyerIdAsync(request.BuyerId);

            if (basket == null)
                return Result.Fail("Basket not found");

            var requestItme = request.Item;

            var updateBasketItemResult = basket.UpdateBasketItem(
                                            requestItme.BasketItemId,
                                            requestItme.Quantity,
                                            requestItme.isDelivery,
                                            requestItme.DelvieryTime);

            if(!updateBasketItemResult.IsSuccess)
                return updateBasketItemResult;

            await _busketRepository.SaveChangesAsync(); 
            
            return new UpdateBasketResult(basket.CustomerBasketId, basket.BuyerId);  
        }
    }
}
