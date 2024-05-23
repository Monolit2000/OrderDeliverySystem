using OrderDeliverySystem.UserAccess.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Application.Users
{
    public class UserAccessApi : IUserAccessApi
    {
        public Task<UserResponse> GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
