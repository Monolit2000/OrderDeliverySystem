using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.UserAccess.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public string FirstName;

        public string LastName;

        public string Name;

        public PhoneNumber PhoneNumber;

        public UserRole Role;

        public bool IsActivated;

        public long ChatId;

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

        public void ActivateUser(long chatId)
        {
            if (IsActivated)
                throw new Exception("User already activated");

            ChatId = chatId;
            IsActivated = true;

            AddDomainEvent(new UserActivatedDomainEvent(UserId));
        }

        public void DeactivateUser()
        {
            if (!IsActivated) 
                throw new Exception("User already deactivated");

            IsActivated = false;
            AddDomainEvent(new UserActivatedDomainEvent(UserId));
        }


        public static User CreateUser(
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
