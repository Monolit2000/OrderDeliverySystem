﻿using Azure.Core;
using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer
{
    public class CreateConsumerCommand : IRequest<Result<CreateConsumerResult>>
    {

        public PhoneNumber PhoneNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Name { get; }

        public long ChatId { get; }    

        public CreateConsumerCommand(
            PhoneNumber phoneNumber, string firstName, string lastName, string name, long chatId) 
        {
            FirstName = firstName;
            LastName = lastName;
            Name = name;
            PhoneNumber = phoneNumber;
            ChatId = chatId;
        }  
    }
}
