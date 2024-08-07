using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.AddItemInBasket
{
    public class AddItemInBasketCommand : IRequest<Result<AddItemInBasketDto>>
    {

        public long BuyerChatId { get; set; }
        public Guid ProductId { get; set; }

        public string Description { get; set; }
        public string ProductImageUrl { get; set; } = "string";

        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public DateTime Day { get; set; }

        public bool IsAdded { get; set; } = false;
        public string? OptionalItemName { get; set; }
        public string? OptionalItemDescription { get; set; }
        public decimal OptionalItemPrice { get; set; } = default;
    }
}
