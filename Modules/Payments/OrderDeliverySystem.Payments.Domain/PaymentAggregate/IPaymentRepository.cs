using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.PaymentAggregate
{
    public interface IPaymentRepository
    {
        public Task AddAsync(Payment payment);
        public Task<Payment> GetByIdAsync(Guid id);

    }
}
