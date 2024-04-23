using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Catalog.Domain.Catalog; 

namespace OrderDeliverySystem.Catalog.Infrastructure.Domain
{
    public class CatalogRepository : ICatalogRepository
    {
        public Task<CatalogItem> GetCatalogItemAsync(Guid ItemId)
        {
            throw new NotImplementedException();
        }
    }
}
