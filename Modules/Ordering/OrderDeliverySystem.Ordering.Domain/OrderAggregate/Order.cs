using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;

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
            //_orderItems = new List<OrderItem>();
        }


        public Order(Guid buyerId, string userName, Address address, string description)
        {
            OrderId = Guid.NewGuid();
            BuyerId = buyerId;
            OrderStatus = OrderStatus.Submitted;
            OrderDate = DateTime.UtcNow;
            Address = address;
            Description = description;

            //// Add the OrderStarterDomainEvent to the domain events collection 
        }


        public Order(Guid buyerId, string userName, Address address) 
        {
            OrderId = Guid.NewGuid();
            BuyerId = buyerId;
            OrderStatus = OrderStatus.Submitted;
            OrderDate = DateTime.UtcNow;
            Address = address;

            //// Add the OrderStarterDomainEvent to the domain events collection 
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


        public void SetCancelledStatus()
        {
            if (OrderStatus == OrderStatus.Paid ||
                OrderStatus == OrderStatus.Shipped)
            {
                throw new Exception($"Is not possible to change the order status from {OrderStatus} to {OrderStatus.Cancelled}.");
            }

            OrderStatus = OrderStatus.Cancelled;
            Description = $"The order was cancelled.";
            //AddDomainEvent(new OrderCancelledDomainEvent(this));
        }

    }
}
