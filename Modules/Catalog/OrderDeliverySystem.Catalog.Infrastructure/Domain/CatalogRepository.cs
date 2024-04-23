using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.Catalog.Infrastructure.Persistence;

namespace OrderDeliverySystem.Catalog.Infrastructure.Domain
{
    public class CatalogRepository : ICatalogRepository
    {
        private CatalogContext _catalogContext;

        public CatalogRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;   
        }

        public async Task AddCatalogItemAsync(CatalogType catalogItem)
        {
            await _catalogContext.AddAsync(catalogItem);

            await _catalogContext.SaveChangesAsync();
        }

        public Task<CatalogItem> GetCatalogItemAsync(Guid ItemId)
        {
            throw new NotImplementedException();
        }
    }
}
