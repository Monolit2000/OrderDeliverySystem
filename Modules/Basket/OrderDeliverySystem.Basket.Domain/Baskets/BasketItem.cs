using FluentResults;
using OrderDeliverySystem.Basket.Domain.Baskets.Event;
using OrderDeliverySystem.CommonModule.Domain;

namespace OrderDeliverySystem.Basket.Domain.Baskets
{
    public class BasketItem : Entity
    {
        public Guid BasketItemId { get; private set; }  
        public Guid ProductId { get; private set; }
        public string ProductImageUrl { get; private set; }
        public Guid CustomerBasketId { get; private set; }
        public CustomerBasket CustomerBasket { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; } = 1;
        public bool IsDelivery { get; private set; }    

        public DateTime DeliveryDateTime { get; private set; }
        public DateTime Day { get; private set; }


        private BasketItem() { } // For Ef core

        public BasketItem(
            Guid productId,
            string productName,
            decimal unitPrice,
            DateTime day,
            string productImageUrl,
            int quantity = 1)
        {
            if (unitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative.", nameof(unitPrice));

            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Day = day;
            ProductImageUrl = productImageUrl;
        }

        public static BasketItem CreateNew(
            Guid productId,
            string productName,
            decimal unitPrice,
            DateTime day,
            string productImageUrl,
            int quantity = 1)
        {
            return new BasketItem(
                productId, 
                productName,
                unitPrice, 
                day,
                productImageUrl, 
                quantity);    
        }

        public Result UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                return Result.Fail($"Quantity cannot be negative {nameof(newQuantity)}");

            Quantity = newQuantity;
            AddDomainEvent(new BasketItemQuantityUpdatedDomainEvent(BasketItemId, newQuantity));
            return Result.Ok();
        }

        public Result SetDelivery(
            bool isDelivery,
            DateTime deliveryDateTime)
        {
            IsDelivery = isDelivery;
            DeliveryDateTime = deliveryDateTime;

            AddDomainEvent(new BasketItemDeliverySetDomainEvent(
                BasketItemId, 
                isDelivery, 
                deliveryDateTime));

            return Result.Ok();
        }

        public Result UpdateUnitPrice(decimal newUnitPrice)
        {
            if (newUnitPrice < 0)
                return Result.Fail($"Unit price cannot be negative {nameof(newUnitPrice)}");

            UnitPrice = newUnitPrice;
            AddDomainEvent(new BasketItemUnitPriceUpdatedDomainEvent(
                BasketItemId,
                newUnitPrice));

            return Result.Ok();
        }

        public Result UpdateProductInfo(
            string newProductName,
            string newProductImageUrl)
        {
            ProductName = newProductName;
            ProductImageUrl = newProductImageUrl;

            AddDomainEvent(new BasketItemProductInfoUpdatedDomainEvent(
                BasketItemId, 
                newProductName,
                newProductImageUrl));

            return Result.Ok();
        }

        public Result UpdateDay(DateTime newDay)
        {
            Day = newDay;
            AddDomainEvent(new BasketItemDayUpdatedDomainEvent(
                BasketItemId,
                newDay));

            return Result.Ok();
        }
    }
}
