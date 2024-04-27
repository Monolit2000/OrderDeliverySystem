using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays
{
    public class GetOllItemsByDaysQuery  : IRequest<Result<List<ItemsByDaysDto>>>
    {
    }
}
