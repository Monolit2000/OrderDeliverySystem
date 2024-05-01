using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.BuyerAggregate
{
    public interface IBuyerRepository
    {
        Task AddAsync(Buyer buyer);
        Buyer Update(Buyer buyer);
        Task<Buyer> FindAsync(long chatId);
        Task<Buyer> FindByIdAsync(int id);
    }
}
