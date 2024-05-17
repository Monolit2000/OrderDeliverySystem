using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public interface IOrderRepository
    {
        public Task AddAsync(Order order);

        public void Update(Order order);

        public Task<Order> GetAsync(Guid orderId);

        public Task<List<Order>> GetOllOrderAsyncByChatId(long chatId);

        public Task<List<Order>> GetOllOrders();

        public Task SaveChangesAsync();
    }
}
