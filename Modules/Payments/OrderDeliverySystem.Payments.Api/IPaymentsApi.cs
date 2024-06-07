using FluentResults;
using OrderDeliverySystem.Payments.Api.GetCheckoutUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Api
{
    public interface IPaymentsApi
    {
        public Task<Result<PaymentCheckoutResponce>> GetCheckoutUrl(GetCheckoutUrlRequest request);
    }
}
