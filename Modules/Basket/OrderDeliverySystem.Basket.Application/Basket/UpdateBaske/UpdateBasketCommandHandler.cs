using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, UpdateBasketResult>
    {

        private readonly IBasketRepository _busketRepository;

        public UpdateBasketCommandHandler(IBasketRepository userRepository)
        {
            _busketRepository = userRepository;
        }



        public Task<UpdateBasketResult> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
