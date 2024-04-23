using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public interface ICatalogRepository
    {

        public Task<CatalogItem> GetCatalogItemAsync(Guid ItemId);

        public Task AddCatalogItemAsync(CatalogType catalogItem);


    }
}
