using FluentResults;
using MediatR;
using OrderDeliverySystem.Ordering.Domain.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Ordering.Application.Buyers.AddBuyer
{
    public class AddBuyerCommand : IRequest<Result<BuyerDto>>
    {

        public Guid UserId { get; }

        public string PhoneNumber { get; }

        public long ChatId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }

        public AddBuyerCommand(Guid userId, string phoneNumber, long chatId, string firstName, string lastName, string name)
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
