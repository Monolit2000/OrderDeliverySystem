using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Domain.Users.DomainErrors
{
   public class UserErrors
   {
        public static string UserWithPhoneNumberAlreadyExists(string phoneNumber) =>
            $"A user with this '{phoneNumber}' already exists";

        public static string UserWithChatIdAlreadyExists =>
            "You are already registered under a different phone number, you can change your current phone number in your profile.";
    }
}
