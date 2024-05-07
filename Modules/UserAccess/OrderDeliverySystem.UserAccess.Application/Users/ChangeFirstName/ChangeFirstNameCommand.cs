using FluentResults;
using MediatR;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangeFirstName
{
    public class ChangeFirstNameCommand : IRequest<Result<ChangeFirstNameDto>>
    {
        public long ChatId { get; set; }

        public string FirstName { get; set; }

    }
}