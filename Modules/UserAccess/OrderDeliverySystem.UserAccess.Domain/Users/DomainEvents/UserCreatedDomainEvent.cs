using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users.DomainEvents
{
    public class UserCreatedDomainEvent : DomainEventBase
    {
        public Guid Id { get; }

        public UserCreatedDomainEvent(Guid id)
        {
            Id = id;
        }
    }
}
