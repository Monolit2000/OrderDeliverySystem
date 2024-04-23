using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.CreateBasket
{
    public class CreateBasketCommand : IRequest<CreateBasketResult>
    {
        public Guid BuyerId { get; set; }

        public long BuyerChatId { get; set; }

        public CreateBasketCommand(Guid buyerId, long buyerChatId)
        {
            BuyerId = buyerId;
            BuyerChatId = buyerChatId;
        }
    }
}
