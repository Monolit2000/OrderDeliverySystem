using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Authentication
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActivated;

        public long ChatId;

        public string Name { get; set; }

        public List<UserRole> Role { get; set; }

    }
}
