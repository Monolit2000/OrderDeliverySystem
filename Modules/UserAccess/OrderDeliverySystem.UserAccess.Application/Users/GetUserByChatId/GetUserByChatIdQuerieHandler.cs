using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.GetUserByChatId
{
    public class GetUserByChatIdQuerieHandler : IRequestHandler<GetUserByChatIdQuerie, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByChatIdQuerieHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> Handle(GetUserByChatIdQuerie request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByChatId(request.ChatId);

            if (user == null)
                return Result.Fail("User not found");

            var userDto = new UserDto(
                user.UserId, 
                user.FirstName, 
                user.LastName,
                user.Name,
                user.PhoneNumber.Number,
                user.Role.Value, 
                user.Address, 
                user.IsActivated, 
                user.ChatId);

            return userDto;
        }
    }
}
