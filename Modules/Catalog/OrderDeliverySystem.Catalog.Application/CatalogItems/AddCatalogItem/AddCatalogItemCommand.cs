using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
namespace OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem
{
    public class AddCatalogItemCommand : IRequest<Result<SmallCatalogItemDto>> 
    {

        public string Name { get; set; }
        public DateTime TimeToExist { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string? OptionalItemName { get; set; }
        public string? OptionalItemDescription { get; set; } 
        public decimal OptionalItemPrice { get; set; } = default;

        //public bool Drink { get; set; }

    }
}
