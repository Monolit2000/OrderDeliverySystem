using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.Payers
{
    public class PayerId : TypedIdValueBase
    {
        public PayerId(Guid value)
            : base(value)
        {
                
        }
    }
}
