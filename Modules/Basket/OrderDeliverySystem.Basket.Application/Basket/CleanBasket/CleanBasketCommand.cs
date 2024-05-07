using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.CleanBasket
{
    public class CleanBasketCommand : IRequest<Result<CleanBasketDto>>
    {
        public long BuyerChatId { get; set; }
    }
}
