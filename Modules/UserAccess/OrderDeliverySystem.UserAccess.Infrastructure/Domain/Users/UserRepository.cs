using OrderDeliverySystem.UserAccess.Domain.Users;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {

        private UserAccessContext _userAccessContext;

        public UserRepository(UserAccessContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }

        public async Task AddAsync(User user)
        {
            await _userAccessContext.Users.AddAsync(user);
        }
    }
}
