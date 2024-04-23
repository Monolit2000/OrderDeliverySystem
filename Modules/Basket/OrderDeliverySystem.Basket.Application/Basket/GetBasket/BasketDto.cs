using OrderDeliverySystem.Basket.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.GetBasket
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }

        public Guid BuyerId { get; set; }

        public List<BasketItem> BasketItems { get; set; } = [];
    }
}
