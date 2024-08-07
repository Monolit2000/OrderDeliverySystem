using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.EditCatalogItem
{
    public class EditCatalogItemCommand : IRequest<Result<EditCatalogItemDto>>
    {
        public Guid CatalogItemId { get; set; }
        //public IFormFile? photo { get; set; }
        public string? Name { get; set; }
        public DateTime TimeToItemExist { get; set; }
        public string? Description { get; set; }
        public decimal  Price { get; set; }
        public string? PictureUri { get; set; }

        public string? OptionalItemName { get; set; }
        public string? OptionalItemDescription { get; set; }
        public decimal OptionalItemPrice { get; set; } = default;

        //public EditCatalogItemCommand(Guid catalogItemId, string name, DateTime timeToItemExist, string description, decimal price, string pictureUri)
        //{
        //    CatalogItemId = catalogItemId;
        //    Name = name;
        //    TimeToItemExist = timeToItemExist;
        //    Description = description;
        //    Price = price;
        //    PictureUri = pictureUri;
        //}
    }
}
