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

        private string FirstName;

        private string LastName;

        private string Name;

        private PhoneNumber PhoneNumber;

        private List<UserRole> Reoles;

        private bool _isActivated;

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
            Reoles = [role];

            this.AddDomainEvent(new UserCreatedDomainEvent(UserId));
        }

        public void ActivateUser()
        {
            if (_isActivated)
                throw new Exception("User already activated");

            _isActivated = true;

            AddDomainEvent(new UserActivatedDomainEvent(UserId));
        }

        public void DeactivateUser()
        {
            if (!_isActivated) 
                throw new Exception("User already deactivated");

            _isActivated = false;
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
