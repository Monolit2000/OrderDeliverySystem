using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public interface ICatalogRepository
    {
        public Task<CatalogItem> GetCatalogItemByIdAsync(Guid ItemId);

        public Task AddCatalogTypeAsync(CatalogType catalogItem);

        public IQueryable<CatalogItem> GetOllCatalogItemQueryable();

        public Task AddCatalogItemAsync(CatalogItem catalogItem);

        public Task<bool> RemoveByIdCatalogItemAsync(Guid catalogItemId);

        public Task GetEstablishmentById(Guid Id);

        public Task<bool> CatalogTypeExistByIdAsync(Guid id);

        public Task<bool> EstablishmentExistByIdAsync(Guid id);

        public Task<bool> CatalogTypeExistByTypeAsync(string Type);

    }
}
