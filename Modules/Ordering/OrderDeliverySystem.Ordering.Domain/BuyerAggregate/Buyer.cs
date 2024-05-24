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

        public long BuyerChatId { get; private set; }

        public string PhoneNumber { get; private set; }
        
        public string FirstName { get; private set; }
        
        public string LastName { get; private set; }
        
        public string Name { get; private set; } 
        
        public string WorkAddress { get; private set; }

        public Buyer()
        {

        }

        public Buyer(Guid byerId, string name, string phoneNumber) 
        {
            BuyerId = byerId;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber;
        }

        public Buyer(Guid byerId, long buyerChatId, string firstName, string lastName, string name, string phoneNumber) 
        {
            BuyerId = byerId;
            BuyerChatId = buyerChatId;
            FirstName = firstName;
            LastName = lastName;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber;
            WorkAddress = "Default";
        }

        public Buyer(Guid byerId, long buyerChatId, string firstName, string lastName, string name, string phoneNumber, string workAddress)
        {
            BuyerId = byerId;
            BuyerChatId = buyerChatId;
            FirstName = firstName;
            LastName = lastName;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber;
            WorkAddress = workAddress;
        }

    }
}
