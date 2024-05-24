using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate
{
    public interface IPaymentRepository
    {
        public Task<Payment> GetByOrderIdAsync(Guid orderId);

        public Task AddAsync(Payment payment);
    }
}
