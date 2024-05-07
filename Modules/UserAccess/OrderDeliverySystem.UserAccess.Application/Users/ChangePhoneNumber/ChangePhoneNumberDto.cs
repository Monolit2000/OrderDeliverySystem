using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangePhoneNumber
{
    public class ChangePhoneNumberDto
    {
        public string OldPhoneNumber { get; set; }

        public string NewPhoneNumber { get; set; }

        public ChangePhoneNumberDto(string oldPhoneNumber, string newPhoneNumber)
        {
            OldPhoneNumber = oldPhoneNumber;
            NewPhoneNumber = newPhoneNumber;
        }
    }
}
