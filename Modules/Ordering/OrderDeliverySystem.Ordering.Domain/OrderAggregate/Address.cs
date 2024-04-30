using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public string Place { get; private set; }

        public Address() { }

        public Address(string place)
        {
            Place = place;
        }
    }
}
