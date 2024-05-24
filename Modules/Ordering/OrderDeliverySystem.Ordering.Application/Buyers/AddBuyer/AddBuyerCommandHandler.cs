using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Buyers.AddBuyer
{
    public class AddBuyerCommandHandler : IRequestHandler<AddBuyerCommand, Result<BuyerDto>>
    {
        private readonly IBuyerRepository _buyerRepository;

        public AddBuyerCommandHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Result<BuyerDto>> Handle(AddBuyerCommand request, CancellationToken cancellationToken)
        {
            var buerExist = await _buyerRepository.FindAsync(request.ChatId);
            
            if (buerExist != null)
            {
                await _buyerRepository.Delete(buerExist);

                //return new BuyerDto() 
                //{
                //    BuyerId = request.UserId,
                //    BuyerChatId = request.ChatId 
                //};
            }

            var buyer = new Buyer(request.UserId, request.ChatId, request.FirstName, request.LastName, request.Name, request.PhoneNumber);

            await _buyerRepository.AddAsync(buyer);

            var buyerDto = new BuyerDto
            { 
                BuyerId = buyer.BuyerId, 
                BuyerChatId = buyer.BuyerChatId
            };

            return buyerDto;
        }
    }
}
