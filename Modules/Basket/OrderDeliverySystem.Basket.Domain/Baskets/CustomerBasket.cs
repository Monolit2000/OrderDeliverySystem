using FluentResults;
using OrderDeliverySystem.Basket.Domain.Baskets.Event;
using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class CustomerBasket : Entity, IAggregateRoot
    {

        public Guid CustomerBasketId { get; private set; }

        public long BuyerChatId { get; private set; }

        public Guid BuyerId { get; private set; }

        //  private List<BasketItem> _basketItem = [];

        public List<BasketItem> Items { get; private set; } = [];

        private CustomerBasket() { } // For Ef Core

        public CustomerBasket(Guid buyerId, long buyerChatId)
        {
            CustomerBasketId = Guid.NewGuid();
            BuyerId = buyerId;
            BuyerChatId = buyerChatId;
        }

        public static CustomerBasket CreateNew(Guid buyerId, long buyerChatId)
        {
            return new CustomerBasket(
                buyerId,
                buyerChatId);
        }


        public Result UpdateBasketItem(
            Guid ItemId, 
            int quantity = 1,
            bool isDelivery = false, 
            DateTime delvieryTime = default,
            OptionalItem optionalItem = null)
        {
            var basketItem = Items.FirstOrDefault(o => o.BasketItemId == ItemId);

            if (basketItem == null)
                return Result.Fail("Item not found");

            if (quantity > 1)
                basketItem.UpdateQuantity(quantity);

            if (isDelivery != basketItem.IsDelivery)
                basketItem.SetDelivery(isDelivery, delvieryTime);
            // basketItem.IsDelivery = isDelivery; 

            //chenged isDelivery == true &&
            if (delvieryTime != default)
                basketItem.SetDelivery(isDelivery, delvieryTime);

            if (optionalItem != null)
                basketItem.AddOptionalItem(optionalItem);
            //basketItem.DeliveryDateTime = delvieryTime;
            return Result.Ok();
        }
     

        public Result AddItem(BasketItem item)
        {
            var existingOrderForProduct = Items.FirstOrDefault(o => o.ProductId == item.ProductId);

            if (existingOrderForProduct != null)
                return Result.Fail("$Товар '{request.ProductName}' вже наявний у кошику");

            Items.Add(item);

            AddDomainEvent(new BasketItemAddedDomainEvent());
            return Result.Ok();
        }

        public Result RemoveItem(Guid BasketItemId)
        {
            var item = Items.FirstOrDefault(o => o.BasketItemId == BasketItemId);

            if (item == null)
                return Result.Fail("$Товар '{request.ProductName}' не наявний у кошику");

            Items.Remove(item);

            AddDomainEvent(new BasketItemRemovedDomainEvent());
            return Result.Ok();
        }


        public Result CleanBasket()
        {
            if (!Items.Any())
                return Result.Ok();

            Items.Clear();
            AddDomainEvent(new BasketClearedDomainEvent());
            return Result.Ok();
        }
    }
}
