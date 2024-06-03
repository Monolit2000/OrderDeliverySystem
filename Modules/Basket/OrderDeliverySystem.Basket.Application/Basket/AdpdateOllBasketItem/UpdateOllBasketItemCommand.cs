using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Application.Basket.UpdateBaske;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.AdpdateOllBasketItem
{
    public class UpdateOllBasketItemCommand : IRequest<Result<UdpdateOllBasketItemDto>>
    {
        public Guid BuyerId { get; set; }

        public UpdateBasketItemDto Item { get; set; }

    }
}
