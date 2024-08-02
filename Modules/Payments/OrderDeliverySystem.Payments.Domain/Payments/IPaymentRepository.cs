using OrderDeliverySystem.Payments.Domain.Payers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Payments.Domain.Payments
{
    public interface IPaymentRepository
    {
        public Task<Payment> GetByOrderIdAsync(Guid orderId);

        public Task AddAsync(Payment payment);

        public Task SaveChangesAsync();

        public Task<List<Payment>> GetPaymentsByUserId(PayerId payerId);

        public Task<List<Payment>> GetAllPayments();

    }
}
