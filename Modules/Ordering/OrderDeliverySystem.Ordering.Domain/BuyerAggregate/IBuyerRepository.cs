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

        Task Delete(Buyer buyer);

        Task<Buyer> GetByChatIdAsync(long chatId);
        Task<Buyer> GetByIdAsync(int id);
    }
}
