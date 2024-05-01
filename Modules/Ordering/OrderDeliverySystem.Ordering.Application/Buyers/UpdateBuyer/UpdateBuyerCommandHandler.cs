using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Buyers.UpdateBuyer
{
    public class UpdateBuyerCommandHandler : IRequestHandler<UpdateBuyerCommand, Result<UpdateBuyerDto>>
    {
        private readonly IBuyerRepository _buyerRepository;

        public UpdateBuyerCommandHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Result<UpdateBuyerDto>> Handle(UpdateBuyerCommand request, CancellationToken cancellationToken)
        {

           var buyerToUpdate = await _buyerRepository.FindAsync(request.ChatId);

            throw new NotImplementedException();

        }
    }
}
