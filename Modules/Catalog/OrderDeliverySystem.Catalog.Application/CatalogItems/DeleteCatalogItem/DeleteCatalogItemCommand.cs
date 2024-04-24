using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.DeleteCatalogItem
{
    public class DeleteCatalogItemCommand :  IRequest<Result<DeleteCatalogItemDto>>
    {
        public Guid CatalogItemId { get; set; }

        public DeleteCatalogItemCommand(Guid catalogItemId)
        {
            CatalogItemId = catalogItemId;
        }
    }
}
