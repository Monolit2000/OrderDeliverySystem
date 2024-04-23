using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class CustomerBasket : Entity, IAggregateRoot
    {
     
        public Guid BasketId { get; private set; }

        public long BuyerChatId { get; private set; }    

        public Guid BuyerId { get; private set; }

        //public List<BasketItem> Items { get; set; } = [];

        private CustomerBasket()
        {

        }

        //public CustomerBasket() { }

        public CustomerBasket(Guid buyerId, long buyerChatId)
        {
            BasketId = Guid.NewGuid();
            BuyerId = buyerId;  
            BuyerChatId = buyerChatId;
           // Items = new List<BasketItem>(); 
        }
    }
}
