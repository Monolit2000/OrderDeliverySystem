using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddCatalogItemAsync(CatalogItem catalogItem)
        {
            await _catalogContext.AddAsync(catalogItem);

            await _catalogContext.SaveChangesAsync();
        }

        public async Task AddCatalogTypeAsync(CatalogType catalogType)
        {
            await _catalogContext.AddAsync(catalogType);

            await _catalogContext.SaveChangesAsync();
        }

        public async Task<bool> CatalogTypeExistByIdAsync(Guid id)
        {
            return await _catalogContext.CatalogTypes.AnyAsync(type => type.CatalogTypeId == id);
        }


        public async Task<bool> EstablishmentExistByIdAsync(Guid id)
        {
            return await _catalogContext.Establishments.AnyAsync(e => e.EstablishmentId == id);
        }

        public Task<CatalogItem> GetCatalogItemByIdAsync(Guid ItemId)
        {
            throw new NotImplementedException();
        }

        public Task GetEstablishmentById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CatalogItem> GetOllCatalogItemQueryable()
        {
            var ItemsQueryable = (IQueryable<CatalogItem>)_catalogContext.CatalogItems;

            return ItemsQueryable;
        }

        public async Task<bool> CatalogTypeExistByTypeAsync(string Type)
        {
            return await _catalogContext.CatalogTypes.AnyAsync(type => type.Type == Type);
        }

        public async Task<bool> RemoveByIdCatalogItemAsync(Guid catalogItemId)
        {
            var item = await _catalogContext.CatalogItems.FindAsync(catalogItemId);

            if (item == null)
                return false;
            
            _catalogContext.CatalogItems.Remove(item);
         
            await _catalogContext.SaveChangesAsync();

            return true; 
        }
    }
}
