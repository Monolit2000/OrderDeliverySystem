using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class BasketItem : Entity
    {
        public Guid BasketItemId { get; set; }  
        public Guid ProductId { get; set; }
        public string ProductImageUrl { get; set; }
        public Guid CustomerBasketId { get; set; }
        public CustomerBasket CustomerBasket { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public bool IsDelivery { get; set; }    

        public DateTime DeliveryDateTime { get; set; }

        public DateTime Day { get; set; }


        public BasketItem()
        {
                
        }

        public BasketItem(
            Guid productId,
            string productName,
            decimal unitPrice,
            DateTime day,
            string productImageUrl,
            int quantity = 1)
        {
            if (unitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative.", nameof(unitPrice));

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

         //   BasketItemId = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Day = day;
            ProductImageUrl = productImageUrl;
        }

        // public DeliveryOptions delivery { get; set; } = default;
    }
}
