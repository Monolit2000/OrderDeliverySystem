using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangeLastName
{
    public class ChangeLastNameDto
    {
        public string OldLastName { get; set; }

        public string NewLastName { get; set; }

        public ChangeLastNameDto(string oldLastName, string newLastName)
        {
            OldLastName = oldLastName;
            NewLastName = newLastName;
        }
    }
}
