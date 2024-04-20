using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;


namespace OrderDeliverySystem.UserAccess.Application.Authentication
{
    public class ActivateUserCommand : IRequest<ActivateResult>
    {
        public PhoneNumber PhoneNumber { get; }

        public long ChatId { get; }

        public ActivateUserCommand(PhoneNumber phoneNumber, long chatId)
        {
            PhoneNumber = phoneNumber;
            ChatId = chatId;
        }
    }
}
