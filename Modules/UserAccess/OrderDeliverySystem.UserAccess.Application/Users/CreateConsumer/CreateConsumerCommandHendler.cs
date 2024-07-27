using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Authentication;
using OrderDeliverySystem.UserAccess.Domain.Users;
using OrderDeliverySystem.UserAccess.Domain.Users.DomainErrors;

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
                return Result.Fail(UserErrors.UserWithPhoneNumberAlreadyExists(request.PhoneNumber.Number));

            if(userByChatIdAlreadyExist != null)
                return Result.Fail(UserErrors.UserWithChatIdAlreadyExists);

            var newUser = User.CreateCustomer(
                request.PhoneNumber,
                request.FirstName,
                request.LastName,
                request.Name);

            newUser.ActivateUser(
                request.ChatId,
                newUser.PhoneNumber.Number, 
                newUser.FirstName, 
                newUser.LastName,
                newUser.Name);

            await _userRepository.AddAsync(newUser);

            var userDto = new UserDto()
            {
                Id = newUser.UserId,
                PhoneNumber = newUser.PhoneNumber.Number,
                ChatId = newUser.ChatId,
                IsActivated = newUser.IsActivated,
                Name = newUser.Name,
                Role = newUser.Role.Value
            };

            return new CreateConsumerResult(userDto);
        }
    }
}
