using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.ChangeOrderStaus
{
    public class ChangeOrderStatusDto
    {
        public Guid OrderId { get; set; }

        public string OrderStatus { get; set; }

    }
}
