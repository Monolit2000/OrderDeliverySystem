using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using OrderDeliverySystem.Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Domain
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

        public async Task<Buyer> FindAsync(long chatId)
        {
          return  await _orderContext.Buyers.FirstOrDefaultAsync(o=> o.BuyerChatId == chatId);
        }

        public Task<Buyer> FindByIdAsync(int id)
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
