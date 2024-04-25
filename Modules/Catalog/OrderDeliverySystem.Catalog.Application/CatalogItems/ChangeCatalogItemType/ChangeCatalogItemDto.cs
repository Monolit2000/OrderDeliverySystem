using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.ChangeCatalogItemType
{
    public class ChangeCatalogItemDto
    {
        public Guid OldTypeId { get; set; }
        public string OldType { get; set; }

        public Guid NewTypeId { get; set; }
        public string NewType { get; set; }
    }
}
