using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public class UserName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        private UserName(
            string firstName, 
            string lastname)
        {
            FirstName = firstName;
            LastName = lastname;
        }

        public static UserName Create(
            string firstName, 
            string lastname)
        {
            return new UserName(
                firstName, 
                lastname);
        }

    }
}
