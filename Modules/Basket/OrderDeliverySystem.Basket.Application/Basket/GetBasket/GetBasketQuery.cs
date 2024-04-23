using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.GetBasket
{
    public class GetBasketQuery : IRequest<BasketDto>
    {
        public long BuyerChatId { get; set; }
    }
}
