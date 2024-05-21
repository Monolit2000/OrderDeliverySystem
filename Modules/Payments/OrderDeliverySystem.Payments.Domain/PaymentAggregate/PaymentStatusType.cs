using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate
{
    public enum PaymentStatusType
    {
        Pending,
        Completed,
        Failed
    }
}
