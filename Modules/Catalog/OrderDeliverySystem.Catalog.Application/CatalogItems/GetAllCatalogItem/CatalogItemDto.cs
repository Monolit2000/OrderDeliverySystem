using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItem
{
    public class CatalogItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUri { get; set; }

        public decimal Price { get; set; }

        public DateOnly Deadline { get; set; }  

        public string PictureUri { get; set; }

    }
}
