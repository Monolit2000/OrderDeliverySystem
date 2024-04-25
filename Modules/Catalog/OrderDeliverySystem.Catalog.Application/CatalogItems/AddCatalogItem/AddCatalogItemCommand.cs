using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
namespace OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem
{
    public class AddCatalogItemCommand : IRequest<Result<SmallCatalogItemDto>> 
    {
        public string Name { get; set; }

        public Guid EstablishmentId { get; set; }

        public Guid CatalogTypeId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUri { get; set; }

    }
}
