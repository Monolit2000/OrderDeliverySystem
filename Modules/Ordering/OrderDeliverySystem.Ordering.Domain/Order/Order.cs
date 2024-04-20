using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;

namespace OrderDeliverySystem.Ordering.Domain.Order
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }

        [Required]
        public Address Address { get; private set; }

        public int? BuyerId { get; private set; }

        public  Buyer buyer { get; private set;}

        public OrderStatus OrderStatus { get; private set; }

        public string Description { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public int? PaymentId { get; private set; }

    }
}
