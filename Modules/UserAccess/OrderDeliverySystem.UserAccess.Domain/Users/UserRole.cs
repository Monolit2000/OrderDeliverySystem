using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users
{
    public class UserRole : ValueObject
    {
        public static UserRole Customer => new UserRole(nameof(Customer));

        public static UserRole Deliverer => new UserRole(nameof(Deliverer));

        public static UserRole Administrator => new UserRole(nameof(Administrator));

        //private static readonly UserRole[] _all = [Customer, Deliverer, Administrator];

        public string Value { get; }

        private UserRole(string value)
        {
            Value = value;
        }

        private UserRole() { }

     
    }
}
