using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Application.Contract
{
    public interface ILiqPayService
    {
        public string GeneratePaymentUrl(double amount, Guid orderId, string? description = null);
    }
}
