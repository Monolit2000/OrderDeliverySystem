using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogTypes.AddCatalogType
{
    public class CatalogTypeDto
    {
        public Guid CatalogTypId { get; set; }

        public string Type { get; set; }

        public CatalogTypeDto(Guid catalogTypId, string type)
        {
            CatalogTypId = catalogTypId;
            Type = type;
        }
    }
}
