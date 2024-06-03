using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.AdpdateOllBasketItem
{
    public class UpdateOllBasketItemCommandHandler : IRequestHandler<UpdateOllBasketItemCommand, Result<UdpdateOllBasketItemDto>>
    {
        private readonly IBasketRepository _busketRepository;

        public UpdateOllBasketItemCommandHandler(IBasketRepository userRepository)
        {
            _busketRepository = userRepository;
        }

        public Task<Result<UdpdateOllBasketItemDto>> Handle(UpdateOllBasketItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
