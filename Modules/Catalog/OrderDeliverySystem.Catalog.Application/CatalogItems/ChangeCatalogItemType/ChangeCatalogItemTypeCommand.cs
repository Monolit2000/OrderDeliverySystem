using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.ChangeCatalogItemType
{
    public class ChangeCatalogItemTypeCommand : IRequest<Result<ChangeCatalogItemDto>>
    {
        public Guid CatalogItemId { get; set; }

        public Guid CatalogTypeId { get; set; }

        public ChangeCatalogItemTypeCommand(
            Guid catalogItemId, 
            Guid catalogTypeId)
        {
            CatalogItemId = catalogItemId;

            CatalogTypeId = catalogTypeId;    
        }
    }
}
