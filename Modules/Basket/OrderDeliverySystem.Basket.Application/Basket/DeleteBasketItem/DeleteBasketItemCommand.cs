using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommand : IRequest<Result<DeleteBasketItemDto>>
    {
        public long BuyerChatId { get; set; }
        public Guid BasketItemId { get; set; }
    }
}
