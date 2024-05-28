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
            var user = await _userRepository.GetUserByChatId(request.ChatId);

            if (user == null)
                return Result.Fail("User not found");

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userByPhoneNumberExist = await _userRepository.GetUserByPhoneNumberAsync(request.PhoneNumber);

                if (userByPhoneNumberExist != null)
                    return Result.Fail("This phone number is already in use");
            }

            var results = new List<Result>
            {
                !string.IsNullOrWhiteSpace(request.FirstName) ? user.ChangeFirstName(request.FirstName) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.LastName) ? user.ChangeLastName(request.LastName) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.PhoneNumber) ? user.ChangePhoneNumber(request.PhoneNumber) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.WorkPlace) ? user.ChangeWorkAddress(request.WorkPlace) : Result.Ok()
            };

            var combinedResult = CombineResults(results);

            if (combinedResult.IsFailed)
                return Result.Fail<UpdateUserDto>(combinedResult.Errors.First());

            await _userRepository.SaveChangesAsync();

            var updateUserDto = new UpdateUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber.Number,
                WorkAddress = user.WorkAddress,
            };

            return updateUserDto;
        }

        private Result CombineResults(IEnumerable<Result> results)
        {
            foreach (var result in results)
            {
                if (result.IsFailed)
                    return result;
            }
            return Result.Ok();
        }

        //private Result CombineResults(IEnumerable<Result> results)
        //{
        //    var failedResult = results.FirstOrDefault(result => result.IsFailed);
        //    return failedResult ?? Result.Ok();
        //}
    }
}
