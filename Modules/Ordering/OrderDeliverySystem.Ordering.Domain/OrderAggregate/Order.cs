using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using FluentResults;
using OrderDeliverySystem.Ordering.Domain.OrderAggregate.DomainEvents;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid OrderId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public string Address { get; private set; }

        public Guid BuyerId { get; private set; }

        public Buyer Buyer { get; private set; }    

        public OrderStatus OrderStatus { get; private set; }

        public string Description { get; private set; }
        public decimal Amount 
        {
            get 
            {
                return OrderItems
                  .Sum(item =>
                      (item.UnitPrice - item.Discount) * item.Units +
                      (item.DeliveryOptions.IsSelfPickup ? 0 : 20));
            }
        }

        private readonly List<OrderItem> _orderItems = [];

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public int? PaymentId { get; private set; }

        private Order()
        {
        }

        public decimal GetAmount() 
            => OrderItems.Sum(item => (item.UnitPrice - item.Discount) * item.Units);
        

        public Order(Guid buyerId, string address)
        {
            OrderId = Guid.NewGuid();
            BuyerId = buyerId;
            OrderStatus = OrderStatus.Submitted;
            OrderDate = DateTime.UtcNow;
            Address = address;
            Description = "The order was submitted";

            //// Add the OrderStarterDomainEvent to the domain events collection 
        }

        public Result ChangeDeliveryTime(Guid orderItemId, DateTime newDeliveriDetaTime)
        {
            var orderItem = OrderItems.FirstOrDefault(oi => oi.OrderItemId == orderItemId);

            if (orderItem == null)
                return Result.Fail("Ored item not found");

            var changeDeliveryTimeResult = orderItem.ChangeDeliveryTime(newDeliveriDetaTime);

            if (changeDeliveryTimeResult.IsFailed)
                return changeDeliveryTimeResult;

            return Result.Ok();
        }


        public Result ChangeDeliveryAddress(Guid orderItemId, string newAddress)
        {
            var orderItem = OrderItems.FirstOrDefault(oi => oi.OrderItemId == orderItemId);

            if (orderItem == null)
                return Result.Fail("Ored item not found");

            var changeDeliveryAddressResult = orderItem.ChangeDeliveryAddress(newAddress);

            if (changeDeliveryAddressResult.IsFailed)
                return changeDeliveryAddressResult;

            return Result.Ok();
        }



        #region Status

        public Result SetSubmittedStatus()
        {
            OrderStatus = OrderStatus.Submitted;
            Description = "Order awaiting validation";

            return Result.Ok();
            //AddDomainEvent(new OrderSubmittedDomainEvent(this));
        }

        public Result SetAwaitingValidationStatus()
        {

            OrderStatus = OrderStatus.AwaitingValidation;
            Description = "Order awaiting validation";

            return Result.Ok();
            //AddDomainEvent(new OrderAwaitingValidationDomainEvent(this));
        }

        public Result SetPaidStatus()
        {
            if (OrderStatus == OrderStatus.Paid)
                return Result.Ok();

            OrderStatus = OrderStatus.Paid;
            Description = "The order was paid";

            AddDomainEvent(new OrderPaidDomainEvent(OrderId, BuyerId));
            return Result.Ok();
        }


        public Result SetShippedStatus()
        {
            OrderStatus = OrderStatus.Shipped;
            Description = "The order was shipped";

            AddDomainEvent(new OrderShippedDomainEvent(OrderId, BuyerId));
            return Result.Ok();
        }


        public Result SetCancelledStatus()
        {
            OrderStatus = OrderStatus.Cancelled;
            Description = $"The order was cancelled.";

            AddDomainEvent(new OrderCancelledDomainEvent(OrderId, BuyerId));
            return Result.Ok();
        }

        public Result PaidFaild(string reason)
        {
            OrderStatus = OrderStatus.PaidFaild;    
            Description = reason;

            AddDomainEvent(new OrderPaymentFailedDomainEvent(OrderId, BuyerId, reason));
            return Result.Ok();  
        }

        #endregion 


        public Order(Guid buyerId, string userName, string address) 
        {
            OrderId = Guid.NewGuid();
            BuyerId = buyerId;
            OrderStatus = OrderStatus.Submitted;
            OrderDate = DateTime.UtcNow;
            Address = address;
            Description = "The order was submitted";

            AddOrderStartedDomainEvent(buyerId, userName);
        }

        private void AddOrderStartedDomainEvent(Guid userId, string userName)
        {
            //var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userId, userName, cardTypeId,
            //                                                            cardNumber, cardSecurityNumber,
            //                                                            cardHolderName, cardExpiration);

            //this.AddDomainEvent(orderStartedDomainEvent);
        }





        public void AddOrderItem(
            Guid orderItemId,
            string productName,
            decimal unitPrice,
            decimal discount,
            string pictureUrl,
            bool isDelivery,
            DateTime deliveryDateTime,
            string address,
            int units = 1)
        {
            var existingOrderForProduct = _orderItems.FirstOrDefault(o => o.ProductId == orderItemId);

            if (existingOrderForProduct != null)
                throw new Exception("Product has already been added");

            var orderItem = new OrderItem(orderItemId, productName, unitPrice, discount, pictureUrl, units);

            if (isDelivery)
                orderItem.AddDeliveryProrerty(deliveryDateTime, address);

            _orderItems.Add(orderItem);
            
        }



    }
}
