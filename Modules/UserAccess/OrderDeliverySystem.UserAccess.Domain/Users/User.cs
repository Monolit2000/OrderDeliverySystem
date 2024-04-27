using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.UserAccess.Domain.Users.DomainEvents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public UserRole Role { get; private set; }

        public bool IsActivated = false;

        public long ChatId { get; private set; }

        private User()
        {
            
        }

        private User(
           Guid id,  PhoneNumber phoneNumber, string firstName, string lastName,  string name, UserRole role)
        {
            UserId = id;    
            PhoneNumber = phoneNumber;
            FirstName = firstName;  
            LastName = lastName;
            Name = name;
            Role = role;

            this.AddDomainEvent(new UserCreatedDomainEvent(UserId));
        }

        public void ActivateUser(long chatId, string phoneNumber, string firstName, string lastName, string name)
        {
            if (IsActivated)
                throw new Exception("User already activated");

            ChatId = chatId;
            IsActivated = true;

            AddDomainEvent(new UserActivatedDomainEvent(UserId, phoneNumber, chatId, firstName,  lastName,  name));
        }


        public void ActivateUser(long chatId)
        {
            if (IsActivated)
                throw new Exception("User already activated");

            ChatId = chatId;
            IsActivated = true;

            AddDomainEvent(new UserActivatedDomainEvent(UserId, PhoneNumber.Number, chatId, FirstName, LastName, Name));
        }


        public void DeactivateUser()
        {
            if (!IsActivated) 
                throw new Exception("User already deactivated");

            IsActivated = false;
            //AddDomainEvent(new UserActivatedDomainEvent(UserId));
        }


        public static User CreateCustomer(
           PhoneNumber phoneNumber, string firstName, string LastName, string name)
        {
            return new User(
                Guid.NewGuid(),
                phoneNumber,
                firstName,
                LastName,
                name,
                UserRole.Customer);

            
        }

        public static User CreateDeliverer(
          PhoneNumber phoneNumber, string firstName, string LastName, string name)
        {
            return new User(
                Guid.NewGuid(),
                phoneNumber,
                firstName,
                LastName,
                name,
                UserRole.Deliverer);
        }

        public static User CreateAdmin(
            PhoneNumber phoneNumber, string firstName, string LastName,string name)
        {
            return new User(
                Guid.NewGuid(),
                phoneNumber,
                firstName,
                LastName,
                name,
                UserRole.Administrator);
        }

    }
}
