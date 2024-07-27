using OrderDeliverySystem.UserAccess.Api;
using OrderDeliverySystem.UserAccess.Domain.Users;

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
            
            if(user == null)
                return new UserResponse(Guid.Parse("4c024333-a4d1-42c3-a537-0df0dd9946ac"), 1111111, "test");

            var responce = new UserResponse(user.UserId, user.ChatId, user.FirstName);

            return responce;    
        }
    }
}
