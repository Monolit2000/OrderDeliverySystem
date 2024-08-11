using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetAllOrdersByBuyerChatId
{
    public class OrderItemDto
    {
        public Guid ItemId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public int Units { get; set; }

        public bool IsDelivery { get; set; }

        public DateTime DeliveryDateTime { get; set; }

        public string PictureUrl { get; set; }

        public string? OptionItemName { get; set; }

        public decimal OptionItemPrice { get; set; } = default;
        //public Guid ItemId { get; set; }

        //public string ProductName { get; set; }

        //public decimal UnitPrice { get; set; }

        //public decimal Discount { get; set; }

        //public int Units { get; set; }

        //public string PictureUrl { get; set; }

        //public DateTime DeliveryDateTime { get; set; }
    }
}
