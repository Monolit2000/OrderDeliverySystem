﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public interface ICatalogRepository
    {
        #region CatalogItem
        public IQueryable<CatalogItem> GetOllCatalogItemQueryable();
        public Task<bool> RemoveCatalogItemByIdAsync(Guid catalogItemId);
        public Task<bool> CatalogTypeExistByIdAsync(Guid id);
        public Task AddCatalogItemAsync(CatalogItem catalogItem);
        public Task<CatalogItem> GetCatalogItemByIdAsync(Guid ItemId);

        #endregion 


        #region Establishment

        public Task AddEstablishmentAsync(Establishment establishment);

        public Task<Establishment> GetEstablishmentById(Guid Id);
        
        public Task<bool> EstablishmentExistByIdAsync(Guid id);

        public Task<Establishment> GetEstablishmentByName(string name);

        #endregion 


        #region CatalogType
        public Task AddCatalogTypeAsync(CatalogType catalogItem);

        public Task<bool> CatalogTypeExistByTypeAsync(string Type);

        #endregion





    }
}
