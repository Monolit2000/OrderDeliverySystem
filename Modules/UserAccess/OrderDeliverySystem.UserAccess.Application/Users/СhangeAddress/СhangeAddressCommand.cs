﻿using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.UserAccess.Application.Users.СhangeAddress
{
    public class СhangeAddressCommand : IRequest<Result<СhangeAddressDto>>
    {
    }
}
