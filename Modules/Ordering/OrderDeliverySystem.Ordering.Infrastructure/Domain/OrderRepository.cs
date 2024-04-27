using OrderDeliverySystem.Ordering.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Domain
{
    public class OrderRepository : IOrderRepository
    {
        public Order Add(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
