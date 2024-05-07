using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangePhoneNumber
{
    public class ChangePhoneNumberCommand : IRequest<Result<ChangePhoneNumberDto>>
    {
        public long ChatId { get; set; }

        public string PhoneNumber { get; set; }
    }
}
