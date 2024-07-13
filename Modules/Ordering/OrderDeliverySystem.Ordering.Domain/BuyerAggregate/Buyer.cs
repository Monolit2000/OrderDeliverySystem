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

        private Buyer() { } // For Ef Core

        private Buyer(
            Guid byerId, 
            long buyerChatId,
            string firstName,
            string lastName,
            string name,
            string phoneNumber) 
        {
            BuyerId = byerId;
            BuyerChatId = buyerChatId;
            FirstName = firstName;
            LastName = lastName;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber;
            WorkAddress = "Default";
        }

        public static Buyer CreateNew(
            Guid byerId,
            long buyerChatId, 
            string firstName,
            string lastName,
            string name,
            string phoneNumber)
        {
            return new Buyer(
                byerId, 
                buyerChatId, 
                firstName, 
                lastName, 
                name,
                phoneNumber);
        }
    }
}
