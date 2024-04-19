using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.DomainEvents
{
    public class UserActivatedDomainEvent : DomainEventBase
    {
        public Guid Id { get; }

        public UserActivatedDomainEvent(Guid id)
        {
            Id = id;
        }
    }
}
