using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class BasketItem : Entity
    {
        public Guid BasketItemId { get; set; }  
        public Guid ProductId { get; set; }
        public Guid CustomerBasketId { get; set; }
        public CustomerBasket CustomerBasket { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;


        public BasketItem()
        {
                
        }

        public BasketItem(
            Guid productId,
            string productName,
            decimal unitPrice,
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
        }

        // public DeliveryOptions delivery { get; set; } = default;
    }
}
