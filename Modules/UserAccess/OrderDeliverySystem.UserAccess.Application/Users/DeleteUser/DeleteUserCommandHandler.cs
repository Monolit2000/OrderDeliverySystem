using FluentResults;
using MediatR;
using OrderDeliverySystem.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository _userRepository) 
        : IRequestHandler<DeleteUserCommand, Result<DeleteUserResult>>
    {
        public Task<Result<DeleteUserResult>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
