using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Application.Basket.GetBasket
{
    public class BasketItemDto
    {
        public Guid BasketItemId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public string ProductImageUrl { get; set; }
        public bool IsDelivery { get; set; }

        public string Description { get; set; }

        public bool IsAdded { get; set; } = false;
        public string? OptionalItemName { get; set; }
        public string? OptionalItemDescription { get; set; }
        public decimal OptionalItemPrice { get; set; } = default;

        public DateTime DeliveryDateTime { get; set; }

        public DateTime Day { get; set; }
    }
}
