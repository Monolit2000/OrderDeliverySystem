using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Users.GetOllActiveConsumers;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.GetOllActiveUsers
{
    public class GetOllActiveUserQuerieHandler : IRequestHandler<GetOllActiveUserQuerie, Result<List<ActiveUserDto>>>
    {
        private readonly IUserRepository _userRepository;

        public GetOllActiveUserQuerieHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<ActiveUserDto>>> Handle(GetOllActiveUserQuerie request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetGetOllActiveUser();

            var usersDto = users.Select(user => new ActiveUserDto
            {
                Id = user.UserId,
                ChatId = user.ChatId,
                UserName = user.FirstName

            }).ToList();

            return usersDto;
        }
    }
}
