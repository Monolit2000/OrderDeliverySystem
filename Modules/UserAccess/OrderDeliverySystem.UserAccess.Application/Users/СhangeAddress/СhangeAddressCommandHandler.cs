using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.СhangeAddress
{
    public class СhangeAddressCommandHandler : IRequestHandler<СhangeAddressCommand, Result<СhangeAddressDto>>
    {
        public Task<Result<СhangeAddressDto>> Handle(СhangeAddressCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
