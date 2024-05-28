using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result<UpdateUserDto>>
    {
        public long ChatId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string WorkPlace { get; set; }
    }
}
