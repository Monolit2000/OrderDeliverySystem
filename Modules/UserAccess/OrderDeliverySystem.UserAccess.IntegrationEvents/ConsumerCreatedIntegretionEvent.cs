using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.IntegrationEvents
{
    public class ConsumerCreatedIntegretionEvent : IntegrationEvent
    {

        public Guid UserId { get; }

        public string PhoneNumber { get; }

        public long ChatId { get; } 

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }

        public ConsumerCreatedIntegretionEvent(Guid userId, string phoneNumber, long chatId, string firstName, string lastName, string name, 
            Guid id, DateTime occurredOn) 
            : base(id, occurredOn)
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
