using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Payment.GetPaymentUrl
{
    public class PaymentUrlDto
    {
       public string CheckoutUri { get; private set; }

        public PaymentUrlDto(string сheckoutUri) 
            => CheckoutUri = сheckoutUri;
    }
}
