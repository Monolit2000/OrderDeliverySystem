using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Ordering.Domain.Orders.Events;
using OrderDeliverySystem.Ordering.Domain.Orders.Errors;

namespace OrderDeliverySystem.Ordering.Domain.Orders
{
    public class OrderItem : Entity
    {
        public Guid OrderItemId { get; private set; }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string PictureUrl { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public int Units { get; private set; }

        public DeliveryOptions DeliveryOptions { get; private set; }

        private OrderItem() { }

        public OrderItem(
            Guid orderItemId,
            string productName,
            decimal unitPrice,
            decimal discount,
            string pictureUrl,
            int units = 1)
        {
            ProductId = orderItemId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Discount = discount;
            Units = units;
            PictureUrl = pictureUrl;
            DeliveryOptions = DeliveryOptions.SelfPickup(DateTime.Now, "Default");

            AddDomainEvent(new OrderItemAddedDomainEvent());
        }

        public static OrderItem CreateNew(
            Guid orderItemId,
            string productName,
            decimal unitPrice,
            decimal discount,
            string pictureUrl,
            int units = 1)
        {
            return new OrderItem(
                orderItemId,
                productName,
                unitPrice,
                discount,
                pictureUrl,
                units);
        }

        public Result SetDefoultDeliveryOptions(DateTime dateTime, string selfPickupAddress)
        {
            DeliveryOptions = DeliveryOptions.SelfPickup(dateTime, selfPickupAddress);
            return Result.Ok();
        }

        public Result AddDeliveryProrerty(DateTime dateTime, string address)
        {
            DeliveryOptions = DeliveryOptions.Delivery(dateTime, address, 20);
            return Result.Ok();
        }

        public Result ChangeDeliveryTime(DateTime newDeliveryDateTime)
        {
            if (DeliveryOptions.DeliveryDateTime < DateTime.Now.AddHours(1))
            {
                return Result.Fail(OrderItemErrors.DeliveryTimeTooSoon);
            }

            if (newDeliveryDateTime.Date != DeliveryOptions.DeliveryDateTime.Date)
            {
                return Result.Fail(OrderItemErrors.DeliveryDateMismatch);
            }

            DeliveryOptions = DeliveryOptions.Delivery(
                newDeliveryDateTime,
                DeliveryOptions.Address,
                DeliveryOptions.DeliveryCost);

            return Result.Ok();
        }

        public Result ChangeDeliveryAddress(string newAddress)
        {
            if (DeliveryOptions.DeliveryDateTime < DateTime.Now.AddHours(1))
            {
                return Result.Fail(OrderItemErrors.AddressChangeTooSoon);
            }

            if (string.IsNullOrEmpty(newAddress))
            {
                return Result.Fail(OrderItemErrors.EmptyNewAddress);
            }

            DeliveryOptions = DeliveryOptions.Delivery(
                DeliveryOptions.DeliveryDateTime,
                newAddress,
                DeliveryOptions.DeliveryCost);

            return Result.Ok();
        }
    }
}
