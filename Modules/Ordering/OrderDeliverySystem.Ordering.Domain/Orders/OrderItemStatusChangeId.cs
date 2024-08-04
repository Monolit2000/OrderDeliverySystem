using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.Orders
{
    public class OrderItemStatusChangeId : TypedIdValueBase
    {
        public OrderItemStatusChangeId(Guid value)
            : base(value)
        {
        }
    }
}
