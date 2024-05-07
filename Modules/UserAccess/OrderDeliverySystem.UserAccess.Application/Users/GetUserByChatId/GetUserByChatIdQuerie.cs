using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.GetUserByChatId
{
    public class GetUserByChatIdQuerie : IRequest<Result<UserDto>>
    {
        public long ChatId { get; set; }    
    }
}
