using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetAllOrderItemByDayRange
{
    public class OrderItemDto
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }
        public string PhoneNumber { get; set; }
        public Guid OrderItemId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Units { get; set; }
        public DateTime Deadline { get; set; }

        // public string Address { get; set; }
    }
}
