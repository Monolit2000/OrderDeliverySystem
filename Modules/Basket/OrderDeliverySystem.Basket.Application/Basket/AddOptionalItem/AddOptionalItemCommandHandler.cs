using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.AddOptionalItem
{
    public class AddOptionalItemCommandHandler(
        IBasketRepository basketRepository) : IRequestHandler<AddOptionalItemCommand, Result>
    {
        public Task<Result> Handle(AddOptionalItemCommand request, CancellationToken cancellationToken)
        {
            //var basketItem = basketRepository.GetByBuyerIdAsync(request.BuyerId);

            throw new NotImplementedException();
        }
    }
}
