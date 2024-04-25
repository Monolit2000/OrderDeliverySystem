using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogTypes.GetAllCatalogTypes
{
    public class GetOllCatalogTypeQuery : IRequest<Result<List<CatalogTypeDto>>>
    {

    }
}
