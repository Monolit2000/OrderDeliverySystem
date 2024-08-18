using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Payments.Domain.Payers;
using OrderDeliverySystem.Payments.Domain.Payments;
using OrderDeliverySystem.Payments.Infrastructure.Persistence;


namespace OrderDeliverySystem.Payments.Infrastructure.Domain.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public async Task<Payment?> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.OrderId.Value == orderId);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetPaymentsByUserId(PayerId payerId)
        {
            return await _context.Payments.Where(p => p.PayerId == payerId).ToListAsync();
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}
