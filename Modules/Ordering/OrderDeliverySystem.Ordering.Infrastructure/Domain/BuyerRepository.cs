using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Infrastructure.Domain
{
    public class BuyerRepository : IBuyerRepository
    {
        public Buyer Add(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> FindAsync(long chatId)
        {
            throw new NotImplementedException();
        }

        public Task<Buyer> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Buyer Update(Buyer buyer)
        {
            throw new NotImplementedException();
        }
    }
}
