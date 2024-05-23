using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UpdateUserDto>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userByPhoneNumberExist = await _userRepository.GetUserByPhoneNumberAsync(request.PhoneNumber);

            if (userByPhoneNumberExist != null)
                return Result.Fail("This phone number is already in use");

            var user = await _userRepository.GetUserByChatId(request.ChatId);

            user.ChangeFirstName(request.FirstName);
            user.ChangeLastName(request.LastName);
            user.ChangePhoneNumber(PhoneNumber.Create(request.PhoneNumber).Value);
            user.ChangeWorkAddress(request.Address);

            return new UpdateUserDto {Success = true};
        }
    }
}
