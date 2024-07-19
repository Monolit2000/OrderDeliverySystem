using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Ordering.Domain.Buyers;
using OrderDeliverySystem.Ordering.Infrastructure.Persistence;

namespace OrderDeliverySystem.Ordering.Infrastructure.Domain.Buyers
{
    public class BuyerRepository : IBuyerRepository
    {
        public readonly OrderContext _orderContext;

        public BuyerRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task AddAsync(Buyer buyer)
        {
            await _orderContext.Buyers.AddAsync(buyer);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<Buyer> GetByChatIdAsync(long chatId)
        {
            var buyer = await _orderContext.Buyers
                .FirstOrDefaultAsync(o => o.BuyerChatId == chatId);

            return buyer;
        }

        public Task<Buyer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Buyer Update(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _orderContext.SaveChangesAsync();
        }

        public async Task Delete(Buyer buyer)
        {
            _orderContext.Buyers.Remove(buyer);

            await _orderContext.SaveChangesAsync();
        }
    }
}
