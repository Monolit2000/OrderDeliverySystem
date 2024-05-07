using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public Guid OrderItemId { get; private set; }

        public string ProductName { get; private set; }

        public string PictureUrl { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public int Units { get; private set; }

         public Guid ProductId { get; private set; }

        protected OrderItem() { }

        public OrderItem(Guid orderItemId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {
            //OrderItemId = Guid.NewGuid();

            ProductId = orderItemId;

            ProductName = productName;
            UnitPrice = unitPrice;
            Discount = discount;
            Units = units;
            PictureUrl = pictureUrl;
        }
    }
    
}
