using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Domain.OrderAggregate.DomainEvents
{
    public class OrderStartedDomainEvent : DomainEventBase
    {
        public Order Order { get; private set; }
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public int CardTypeId { get; private set; }
        public string CardNumber { get; private set; }
        public string CardSecurityNumber { get; private set; }
        public string CardHolderName { get; private set; }
        public DateTime CardExpiration { get; private set; }

        public OrderStartedDomainEvent(Order order, Guid userId, string userName, int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName, DateTime cardExpiration)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));
            UserId = userId;
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            CardTypeId = cardTypeId;
            CardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
            CardSecurityNumber = cardSecurityNumber ?? throw new ArgumentNullException(nameof(cardSecurityNumber));
            CardHolderName = cardHolderName ?? throw new ArgumentNullException(nameof(cardHolderName));
            CardExpiration = cardExpiration;
        }
    }
}
