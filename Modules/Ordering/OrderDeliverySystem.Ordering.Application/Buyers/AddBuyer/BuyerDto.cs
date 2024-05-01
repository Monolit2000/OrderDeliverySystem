using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Buyers.AddBuyer
{
    public class BuyerDto
    {
        public Guid BuyerId { get; set; } 
        public long BuyerChatId { get; set; }
    }
}
