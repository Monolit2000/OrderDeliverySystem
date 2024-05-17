using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate;
using OrderDeliverySystem.Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Domain
{
    public class OrderRepository : IOrderRepository
    {
        public readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task AddAsync(Order order)
        {
            await _orderContext.Orders.AddAsync(order);
            await _orderContext.SaveChangesAsync(); 
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            var order = await _orderContext.Orders.FindAsync(orderId);

            if (order != null)
            {
                await _orderContext.Entry(order)
                    .Collection(i => i.OrderItems).LoadAsync();
            }

            return order;
        }

        public async Task<List<Order>> GetOllOrderAsyncByChatId(long chatId)
        {
            var buyer = await _orderContext.Buyers.FirstOrDefaultAsync(b => b.BuyerChatId == chatId);

            if (buyer == null)
                return null;

            var result = _orderContext.Orders
                .Where(o => o.BuyerId == buyer.BuyerId)
                .Include(o => o.OrderItems)
                .ToList();

            return result;

        }

        public async Task<List<Order>> GetOllOrders()
        {
            var result = await _orderContext.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();

            return result;  
        }

        public async Task SaveChangesAsync()
        {
            await _orderContext.SaveChangesAsync();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
