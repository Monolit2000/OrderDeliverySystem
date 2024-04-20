using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.BuyerAggregate
{
    public class Buyer : Entity, IAggregateRoot
    {
        public Guid BuyerId { get; private set; }

        public string PhoneNumber { get; private set; } 

        public string Name { get; private set; }

        public Buyer()
        {

        }

        public Buyer(Guid byerId, string name, string phoneNumber) : this()
        {
            BuyerId = byerId;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber;
        }
    }
}
