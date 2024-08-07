using FluentResults;
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
            var basket = await _busketRepository.GetByBuyerIdAsync(request.BuyerId);

            if (basket == null)
                return Result.Fail("Basket not found");

            var requestItme = request.Item;


            OptionalItem newOptionalItem = new();

            if (requestItme.IsAdded == true && 
                requestItme.OptionalItemName != null &&
                requestItme.OptionalItemDescription != null &&
                requestItme.OptionalItemPrice != default)
            {
                    newOptionalItem = new OptionalItem(
                        requestItme.IsAdded,
                        requestItme.OptionalItemName,
                        requestItme.OptionalItemDescription,
                        requestItme.OptionalItemPrice);
            }

            var updateBasketItemResult = basket.UpdateBasketItem(
                                            requestItme.BasketItemId,
                                            requestItme.Quantity,
                                            requestItme.isDelivery,
                                            requestItme.DelvieryTime,
                                            newOptionalItem);


            if (!updateBasketItemResult.IsSuccess)
                return updateBasketItemResult;

            await _busketRepository.SaveChangesAsync(); 
            
            return new UpdateBasketResult(basket.CustomerBasketId, basket.BuyerId);  
        }
    }
}
