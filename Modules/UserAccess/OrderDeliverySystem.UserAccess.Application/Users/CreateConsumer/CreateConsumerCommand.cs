using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer
{
    public class CreateConsumerCommand : IRequest<CreateConsumerResult>
    {

        public PhoneNumber PhoneNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }


        public CreateConsumerCommand(
            PhoneNumber phoneNumber, string firstName, string lastName, string name) 
        {
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            PhoneNumber = phoneNumber;
        }  
    }
}
