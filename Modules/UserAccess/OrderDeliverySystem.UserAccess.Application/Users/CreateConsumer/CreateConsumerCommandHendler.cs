using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Authentication;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer
{
    internal class CreateConsumerCommandHendler : IRequestHandler<CreateConsumerCommand, Result<CreateConsumerResult>>
    {
        private readonly IUserRepository _userRepository;

        public CreateConsumerCommandHendler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CreateConsumerResult>> Handle(CreateConsumerCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUserByPhoneNumberAsync(request.PhoneNumber.Number);

            var userByChatIdAlreadyExist = await _userRepository.GetUserByChatId(request.ChatId);

            if (user != null)
                return new CreateConsumerResult($"A user with this '{request.PhoneNumber.Number}' already exists");

            if(userByChatIdAlreadyExist != null)
                return Result.Fail($"You are already registered under a different phone number, you can change your current phone number in your profile.  ");

            var newUser = User.CreateCustomer(
                request.PhoneNumber,
                request.Name,
                request.FirstName,
                request.LastName);

            newUser.ActivateUser(request.ChatId, newUser.PhoneNumber.Number, newUser.FirstName, newUser.LastName, newUser.Name);

            await _userRepository.AddAsync(newUser);

            var userDto = new UserDto()
            {
                Id = newUser.UserId,
                PhoneNumber = newUser.PhoneNumber.Number,
                ChatId = newUser.ChatId,
                IsActivated = newUser.IsActivated,
                Name = newUser.Name,
                Role = newUser.Role
            };

            return new CreateConsumerResult(userDto);
        }
    }
}
