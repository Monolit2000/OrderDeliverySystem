using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand, Result<DeleteBasketItemDto>>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketItemCommandHandler(IBasketRepository userRepository)
        {
            _basketRepository = userRepository;
        }

        public async Task<Result<DeleteBasketItemDto>> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketAsync(request.BuyerChatId);

            if (basket == null)
                return Result.Fail("Basket dose not exist");

            if(!basket.RemuveItem(request.BasketItemId))
                return Result.Fail("Item not exist");

            await _basketRepository.SaveChangesAsync();   

            return new DeleteBasketItemDto { Success = true};
        }
    }
}
