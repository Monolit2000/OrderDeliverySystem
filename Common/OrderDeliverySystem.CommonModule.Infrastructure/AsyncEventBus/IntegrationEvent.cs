using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus
{
    public interface IIntegrationEvent : INotification
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }
    }


    public abstract class IntegrationEvent : IIntegrationEvent
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        protected IntegrationEvent(Guid id, DateTime occurredOn)
        {
            this.Id = id;
            this.OccurredOn = occurredOn;
        }
    }
}
