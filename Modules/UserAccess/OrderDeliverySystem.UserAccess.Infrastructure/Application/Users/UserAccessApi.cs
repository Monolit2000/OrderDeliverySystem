using OrderDeliverySystem.UserAccess.Api;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Application.Users
{
    public class UserAccessApi : IUserAccessApi
    {

        private readonly IUserRepository _userRepository;

        public UserAccessApi(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetUserById(id);

            var responce = new UserResponse(user.UserId, user.ChatId, user.FirstName);

            return responce;    
        }
    }
}
