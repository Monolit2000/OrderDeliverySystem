using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Catalog.Domain.Establishments;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public interface ICatalogRepository
    {
        #region CatalogItem
        public IQueryable<CatalogItem> GetAllCatalogItemQueryable();

        public Task<CatalogItem?> GetCatalogItemById(Guid catalogItemId);

        public Task<List<CatalogItem>> GetAllCatalogItems();

        public Task<bool> RemoveCatalogItemByIdAsync(Guid catalogItemId);
        public Task<bool> CatalogTypeExistByIdAsync(Guid id);
        public Task AddCatalogItemAsync(CatalogItem catalogItem);
        public Task<CatalogItem> GetCatalogItemByIdAsync(Guid ItemId);

      

        #endregion 


        #region Establishment

        public Task AddEstablishmentAsync(Establishment establishment);

        public Task<Establishment?> GetEstablishmentById(Guid Id);
        
        public Task<bool> EstablishmentExistByIdAsync(Guid id);

        public Task<Establishment> GetEstablishmentByName(string name);

        public Task<List<Establishment>> GetAllEstablishment();

        #endregion 


        #region CatalogType
        public Task AddCatalogTypeAsync(CatalogType catalogItem);

        public Task<bool> GetCatalogTypeExistByTypeAsync(string Type);

        public Task<CatalogType> GeCatalogTypeByType(string name);

        Task<CatalogType> GetCatalogTypeByIdAsync(Guid id);

        public Task<List<CatalogType>> GetAllCatalogTypeAsync();


        #endregion

        Task SaveChangesAsync();



    }
}
