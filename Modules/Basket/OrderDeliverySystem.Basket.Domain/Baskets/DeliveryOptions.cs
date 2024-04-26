using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class DeliveryOptions
    {
        public Guid DeliveryOptionsId { get; set; }

        public DateTime FeedTime { get; set; }

        public decimal Price { get; set; } = 20; 
    }
}
