using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays
{
    public class ItemsByDaysDto 
    {
        public DateTime Day { get; set; }

        public List<CatalogItemDto> Items { get; set; } = [];

    }
}
