using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Application.Users.GetOllActiveUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.GetOllActiveConsumers
{
    public class GetOllActiveUserQuerie : IRequest<Result<List<ActiveUserDto>>>
    {
    }
}
