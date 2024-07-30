using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.GetOrderItemByDay
{
    public class OrderItemByDayDto
    {
        public Guid OrderId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
