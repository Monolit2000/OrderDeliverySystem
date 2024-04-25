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

        [Key]
        public Guid BasketId { get;  set; }

        //[Required]
        public long BuyerChatId { get;  set; }

        [Required]
        public Guid BuyerId { get;  set; }

        public List<BasketItem> Items { get; set; } = [];

        public CustomerBasket()
        {

        }

        //public CustomerBasket() { }

        public CustomerBasket(Guid buyerId/*, long buyerChatId*/)
        {
            BasketId = Guid.NewGuid();
            BuyerId = buyerId;  
            //BuyerChatId = buyerChatId;
           // Items = new List<BasketItem>(); 
        }

        public CustomerBasket(Guid buyerId, Guid basketId/*, long buyerChatId*/)
        {
            BasketId = basketId;
            BuyerId = buyerId;
            //BuyerChatId = buyerChatId;
            // Items = new List<BasketItem>(); 
        }
    }
}
