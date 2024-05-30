using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class DeliveryOptions : ValueObject
    {
        public string DeliveryMethod { get; private set; }
        public decimal DeliveryCost { get; private set; }
        public DateTime DeliveryDateTime { get; private set; }
        public bool IsSelfPickup { get; private set; }
        public string Address { get; private set; }

        private DeliveryOptions(bool isSelfPickup, string deliveryMethod, string address, decimal deliveryCost, DateTime deliveryDateTime)
        {
            IsSelfPickup = isSelfPickup;
            DeliveryMethod = deliveryMethod;
            Address = address;
            DeliveryCost = deliveryCost;
            DeliveryDateTime = deliveryDateTime;
            IsSelfPickup = isSelfPickup;
        }

        public static DeliveryOptions SelfPickup(DateTime dateTime, string address) => 
            new DeliveryOptions(true, "The takeaway itself", address, 0, dateTime);

        public static DeliveryOptions Delivery(DateTime dateTime, string address, decimal deliveryCost = 0) =>
            new DeliveryOptions(false, "Delivery", address, deliveryCost, dateTime);
    }
}
