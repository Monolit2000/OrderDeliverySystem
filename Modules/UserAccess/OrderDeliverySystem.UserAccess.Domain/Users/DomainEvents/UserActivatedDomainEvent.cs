using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users.DomainEvents
{
    public class UserActivatedDomainEvent : DomainEventBase
    {
        public Guid UserId { get; }

        public string PhoneNumber { get; }

        public long ChatId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }


        public UserActivatedDomainEvent( Guid userId,
            string phoneNumber, long chatId, string firstName, string lastName, string name)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
            ChatId = chatId;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
        }
    }
}
