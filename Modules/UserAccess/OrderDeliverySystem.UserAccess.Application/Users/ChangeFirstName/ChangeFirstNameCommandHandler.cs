using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangeFirstName
{
    public class ChangeFirstNameCommandHandler : IRequestHandler<ChangeFirstNameCommand, Result<ChangeFirstNameDto>>
    {
        private readonly IUserRepository _userRepository;

        public ChangeFirstNameCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<ChangeFirstNameDto>> Handle(ChangeFirstNameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByChatId(request.ChatId);

            if (user == null)
                return Result.Fail("User not found");

            var oldFirstName = user.FirstName;

            user.ChangeFirstName(request.FirstName);

            await _userRepository.SaveChangesAsync();

            return new ChangeFirstNameDto(oldFirstName, user.FirstName);
        }
    }
}
