using FluentResults;
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

    public record PaymentCheckoutResponce(Guid OrderId, string CheckoutUrl);

    public class GetCheckoutUrlRequest()
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
