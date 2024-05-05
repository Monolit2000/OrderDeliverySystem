using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemById
{
    public class GetItemByIdQuerie : IRequest<Result<CatalogItemDto>>
    {
        public Guid ItemId { get; set; }
    }
}
