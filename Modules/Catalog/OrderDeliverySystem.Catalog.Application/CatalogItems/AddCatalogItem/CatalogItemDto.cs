using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem
{
    public class CatalogItemDto
    {
        public Guid CatalogItemId { get; set; }

        public string Name { get; set; }

        public CatalogItemDto(Guid catalogItemId, string name)
        {
            CatalogItemId = catalogItemId;  
            Name = name;
        }

        //public string Description { get; set; }

        //public decimal Price { get; set; }

        //public string PictureUri { get; set; }

        //public Guid ProductId { get; set; }

        //public Guid EstablishmentId { get; set; }

        //public Guid CatalogTypeId { get; set; }
    }
}
