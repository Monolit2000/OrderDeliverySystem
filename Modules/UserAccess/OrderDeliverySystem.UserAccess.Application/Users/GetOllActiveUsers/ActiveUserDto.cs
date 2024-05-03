using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.GetOllActiveUsers
{
    public class ActiveUserDto
    {
        public Guid Id { get; set; }
        public long ChatId { get; set; }
    }
}
