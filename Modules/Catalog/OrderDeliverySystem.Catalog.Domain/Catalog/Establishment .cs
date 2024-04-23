using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public class Establishment
    {
        public Guid EstablishmentId { get; set; } 

        public Guid CatalogItemId { get; set; } 

        public string Name { get; set; }

    }
}
