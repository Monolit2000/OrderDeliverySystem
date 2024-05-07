using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Users.ChangeFirstName;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangeLastName
{
    public class ChangeLastNameCommandHandler : IRequestHandler<ChangeLastNameCommand, Result<ChangeLastNameDto>>
    {
        private readonly IUserRepository _userRepository;

        public ChangeLastNameCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<ChangeLastNameDto>> Handle(ChangeLastNameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByChatId(request.ChatId);

            if (user == null)
                return Result.Fail("User not found");

            var oldLastName = user.LastName;

            user.ChangeLastName(request.LastName);

            await _userRepository.SaveChangesAsync();

            return new ChangeLastNameDto(oldLastName, user.LastName);
        }
    }
}
