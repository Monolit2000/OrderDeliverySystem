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

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid OrderId { get; private set; }

        public DateTime OrderDate { get; private set; }

        [Required]
        public Address Address { get; private set; }

        public Guid BuyerId { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public string Description { get; private set; }


        private readonly List<OrderItem> _orderItems = [];

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public int? PaymentId { get; private set; }

        private Order()
        {
        }

        public Order(Guid buyerId, Address address, string description)
        {
            OrderId = Guid.NewGuid();
            BuyerId = buyerId;
            OrderStatus = OrderStatus.Submitted;
            OrderDate = DateTime.UtcNow;
            Address = address;
            Description = "The order was submitted";

            //// Add the OrderStarterDomainEvent to the domain events collection 
        }

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
            // return Result.Fail("Cannot set status to AwaitingValidation because the order is already paid.");
            //AddDomainEvent(new OrderAwaitingValidationDomainEvent(this));
        }

        public Result SetPaidStatus()
        {
            OrderStatus = OrderStatus.Paid;
            Description = "The order was paid";

            return Result.Ok();
            //return Result.Fail("Cannot set the order status to Paid because it is already Shipped.");
            //AddDomainEvent(new OrderPaidDomainEvent(this));
        }


        public Result SetShippedStatus()
        {
            OrderStatus = OrderStatus.Shipped;
            Description = "The order was shipped";

            return Result.Ok();
            // return Result.Fail("Cannot set status to Shipped because the order is not paid.");
            //AddDomainEvent(new OrderShippedDomainEvent(this));
        }


        public Result SetCancelledStatus()
        {
            OrderStatus = OrderStatus.Cancelled;
            Description = $"The order was cancelled.";

            return Result.Ok();
            // return Result.Fail($"Is not possible to change the order status from {OrderStatus.Value} to {OrderStatus.Cancelled.Value}.");
            //AddDomainEvent(new OrderCancelledDomainEvent(this));
        }


        public Order(Guid buyerId, string userName, Address address) 
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





        public void AddOrderItem(Guid orderItemId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {
            var existingOrderForProduct = _orderItems.FirstOrDefault(o => o.ProductId == orderItemId);

            if (existingOrderForProduct != null)
                throw new Exception("Product has already been added");

            //add validated new order item
            var orderItem = new OrderItem(orderItemId, productName, unitPrice, discount, pictureUrl, units);
            _orderItems.Add(orderItem);
            
        }



    }
}
