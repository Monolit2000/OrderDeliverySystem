using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChengeOrderItemStatus
{
    public class ChengeOrderItemStatusResultDto
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        public string NewStatus { get; set; }
    }
}
