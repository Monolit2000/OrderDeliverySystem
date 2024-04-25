using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Establishments.GetOllEstablishment
{
    public class GetOllEstablishmentQuery : IRequest<Result<List<SmallEstablishmentDto>>>
    {
    }
}
