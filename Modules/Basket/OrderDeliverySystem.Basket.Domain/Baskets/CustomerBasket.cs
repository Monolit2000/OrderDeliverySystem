using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class CustomerBasket : Entity, IAggregateRoot
    {

        public Guid CustomerBasketId { get;  set; }

        public long BuyerChatId { get;  set; }

        public Guid BuyerId { get;  set; }

      //  private List<BasketItem> _basketItem = [];

        public List<BasketItem> Items { get; set; }


        public CustomerBasket()
        {
            Items = new List<BasketItem>();
        }


        public Result UpdateBasketItem(
            Guid ItemId, 
            int quantity = 1,
            bool isDelivery = false, 
            DateTime delvieryTime = default)
        {
            var basketItem = Items.FirstOrDefault(o => o.BasketItemId == ItemId);

            if (basketItem == null)
                return Result.Fail("Item not found");

            if (quantity > 1)
                basketItem.Quantity = quantity;

            if (isDelivery != basketItem.IsDelivery)
                basketItem.IsDelivery = isDelivery; 

            if(isDelivery == true && delvieryTime != default)
                basketItem.deliveryDateTime = delvieryTime;

            return Result.Ok();
        }
     

        public bool AddItem(BasketItem item)
        {
            var existingOrderForProduct = Items.FirstOrDefault(o => o.ProductId == item.ProductId);

            if (existingOrderForProduct != null)
                return false;

            Items.Add(item);
            return true;
        }

        public bool RemuveItem(Guid BasketItemId)
        {
            var item = Items.FirstOrDefault(o => o.BasketItemId == BasketItemId);

            if (item == null)
                return false;

            Items.Remove(item);
            return true;
        }

        public bool CleanBasket()
        {
            Items.Clear();
            return true;
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
