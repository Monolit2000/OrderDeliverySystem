using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItemByWeek
{
    public class OptionalItemDto
    {
        public string? OptionalItemName { get; set; }
        public string? OptionalItemDescription { get; set; }
        public decimal OptionalItemPrice { get; set; } = default;
    }
}
