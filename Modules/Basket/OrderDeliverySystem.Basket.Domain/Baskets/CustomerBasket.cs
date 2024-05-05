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

        public Guid CustomerBasketId { get;  set; }

        //[Required]
        public long BuyerChatId { get;  set; }

        [Required]
        public Guid BuyerId { get;  set; }

      //  private List<BasketItem> _basketItem = [];

        public List<BasketItem> Items { get; set; }


        public CustomerBasket()
        {
            Items = new List<BasketItem>();
        }

        //public CustomerBasket() { }

        public void AddItem(BasketItem item)
        {
            var existingOrderForProduct = Items.FirstOrDefault(o => o.ProductId == item.ProductId);

            if (existingOrderForProduct != null)
                throw new Exception("Product has already been added");

            Items.Add(item);
        }

        public CustomerBasket(Guid buyerId, long buyerChatId)
        {
            CustomerBasketId = Guid.NewGuid();
            BuyerId = buyerId;  
            BuyerChatId = buyerChatId;
        }

        public CustomerBasket(Guid buyerId, Guid basketId/*, long buyerChatId*/)
        {
            CustomerBasketId = basketId;
            BuyerId = buyerId;
            //BuyerChatId = buyerChatId;
            // Items = new List<BasketItem>(); 
        }
    }
}
