using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Users.ChangeLastName;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangePhoneNumber
{
    public class ChangePhoneNumberCommandHandler : IRequestHandler<ChangePhoneNumberCommand, Result<ChangePhoneNumberDto>>
    {
        private readonly IUserRepository _userRepository;

        public ChangePhoneNumberCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<ChangePhoneNumberDto>> Handle(ChangePhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByChatId(request.ChatId);

            if (user == null)
                return Result.Fail("User not found");

            var oldPhoneNumber = user.PhoneNumber.Number;

            //var newPhoneNumber = PhoneNumber.Create(request.PhoneNumber);

            //if (newPhoneNumber.IsFailed)
            //{
            //    var errorMessage = newPhoneNumber.Errors.FirstOrDefault()?.Message ?? "Unknown error";

            //    return Result.Fail(errorMessage);
            //}

            user.ChangePhoneNumber(request.PhoneNumber);

            await _userRepository.SaveChangesAsync();

            return new ChangePhoneNumberDto(oldPhoneNumber, user.PhoneNumber.Number);
        }
    }
}
