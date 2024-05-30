using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
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

        public async Task<CatalogItem?> GetCatalogItemById(Guid catalogItemId)
        {
            var item = await _catalogContext.CatalogItems
                .FirstOrDefaultAsync(ci => ci.CatalogItemId == catalogItemId);

            return item;
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


        public async Task<bool> EstablishmentExistByIdAsync(Guid Id)
        {
            return await _catalogContext.Establishments.AnyAsync(e => e.EstablishmentId == Id);
        }

        public async Task<CatalogItem> GetCatalogItemByIdAsync(Guid ItemId)
        {

            var catalogItem = await _catalogContext.CatalogItems
                //.Include(ci => ci.CatalogType) 
                .FirstOrDefaultAsync(ci => ci.CatalogItemId == ItemId);

            return catalogItem;

            //return await _catalogContext.CatalogItems.FirstOrDefaultAsync(ci => ci.CatalogItemId == ItemId);
        }

        public async Task<Establishment?> GetEstablishmentById(Guid Id)
        {
            return await _catalogContext.Establishments.FirstOrDefaultAsync(e => e.EstablishmentId == Id);
        }

        public IQueryable<CatalogItem> GetOllCatalogItemQueryable()
        {
            var ItemsQueryable = (IQueryable<CatalogItem>)_catalogContext.CatalogItems;

            return ItemsQueryable;
        }

        public async Task<bool> GetCatalogTypeExistByTypeAsync(string Type)
        {
            return await _catalogContext.CatalogTypes.AnyAsync(type => type.Type == Type);
        }

        public async Task<bool> RemoveCatalogItemByIdAsync(Guid catalogItemId)
        {
            var item = await _catalogContext.CatalogItems.FindAsync(catalogItemId);

            if (item == null)
                return false;
            
            _catalogContext.CatalogItems.Remove(item);
         
            await _catalogContext.SaveChangesAsync();

            return true; 
        }

        public async Task<Establishment> GetEstablishmentByName(string name)
        {
            return await _catalogContext.Establishments.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task AddEstablishmentAsync(Establishment establishment)
        {
            await _catalogContext.AddAsync(establishment);

            await _catalogContext.SaveChangesAsync();
        }

        public async Task<CatalogType> GeCatalogTypeByType(string type)
        {
            return await _catalogContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.Type == type);
        }

        public async Task<List<Establishment>> GetOllEstablishment()
        {
            return await _catalogContext.Establishments.ToListAsync();
        }

        public async Task<CatalogType> GetCatalogTypeByIdAsync(Guid id)
        {
            return await _catalogContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.CatalogTypeId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _catalogContext.SaveChangesAsync();   
        }

        public async Task<List<CatalogType>> GetOllCatalogTypeAsync()
        {
            return await _catalogContext.CatalogTypes.ToListAsync();
        }

        public async Task<List<CatalogItem>> GetOllCatalogItems()
        {
            return await _catalogContext.CatalogItems.ToListAsync();
        }

    }
}
