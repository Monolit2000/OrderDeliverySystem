using FluentResults;
using MediatR;
using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.UpdateBaske
{
    public class UpdateBasketCommand : IRequest<Result<UpdateBasketResult>>
    {
        public Guid BuyerId { get; set; }

        public List<BasketItem> Items { get; set; }
    }
}
