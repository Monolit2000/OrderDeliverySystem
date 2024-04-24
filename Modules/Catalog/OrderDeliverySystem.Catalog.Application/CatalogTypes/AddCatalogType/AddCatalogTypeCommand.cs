using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogTypes.AddCatalogType
{
    public class AddCatalogTypeCommand : IRequest<Result<CatalogTypeDto>>
    {
        public string Type { get; set; }

        public AddCatalogTypeCommand(string type)
        {
            Type = type;
        }

    }
}
