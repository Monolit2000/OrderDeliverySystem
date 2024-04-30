using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Orders.CancelOrder
{
    public class CancelOrderDto
    {
        public Guid OrderId { get; private set; }

        public string Status { get; private set; }

        public CancelOrderDto(Guid orderId, OrderStatus status)
        {
            OrderId = orderId;
            Status = status.Value;
        }
    }
}
