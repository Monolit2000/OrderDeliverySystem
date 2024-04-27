using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemsByDays
{
    public class GetItemsByDaysQuery : IRequest<Result<List<ItemsByDaysDto>>>
    {

        public List<DateTime> ListOfDays { get; set; }  

    }
}
