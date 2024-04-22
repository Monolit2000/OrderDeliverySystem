using MediatR;
//using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, CreateBasketResult>
    {
        //private readonly IBasketRepository _userRepository;

   

        Task<CreateBasketResult> IRequestHandler<CreateBasketCommand, CreateBasketResult>.Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
