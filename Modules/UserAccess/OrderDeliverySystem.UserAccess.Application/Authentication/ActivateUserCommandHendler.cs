using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;

namespace OrderDeliverySystem.UserAccess.Application.Authentication
{
    internal class ActivateUserCommandHendler : IRequestHandler<ActivateUserCommand, ActivateResult>
    {
        private readonly IUserRepository _userRepository;

        public ActivateUserCommandHendler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActivateResult> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByPhoneNumberAsync(request.PhoneNumber.Number);

            if (user == null)
                return new ActivateResult( $"A user with this '{request.PhoneNumber.Number}' phone number does not exist ");

            user.ActivateUser(request.ChatId, user.PhoneNumber.Number, user.FirstName, user.LastName, user.Name);

            var userDto = new UserDto()
            {
                Id = user.UserId,
                PhoneNumber = user.PhoneNumber.Number,
                ChatId = user.ChatId,
                IsActivated = user.IsActivated,
                Name = user.Name,
                Role = user.Role
            };

            await _userRepository.SaveChangesAsync();

            return new ActivateResult(userDto);   
        }
    }
}
