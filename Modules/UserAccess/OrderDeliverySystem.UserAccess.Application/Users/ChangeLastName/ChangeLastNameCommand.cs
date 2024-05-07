using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.ChangeLastName
{
    public class ChangeLastNameCommand : IRequest<Result<ChangeLastNameDto>>
    {
        public long ChatId { get; set; }

        public string LastName { get; set; }
    }
}
