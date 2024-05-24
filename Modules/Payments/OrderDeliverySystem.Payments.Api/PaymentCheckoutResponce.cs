using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Api
{
    public record PaymentCheckoutResponce(Guid OrderId, string CheckoutUrl);

}
