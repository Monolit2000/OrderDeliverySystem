using OrderDeliverySystem.CommonModule.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public class CatalogItem : Entity, IAggregateRoot
    {
      
        public Guid CatalogItemId { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        public Establishment Establishment { get; private set; }

        public CatalogType CatalogType { get; set; }


        public Guid EstablishmentId { get; set; }

        public Guid CatalogTypeId { get; set; }

        private CatalogItem() 
        {

        }    


        public CatalogItem( 
            string name,
            Guid establishmentId, 
            Guid catalogTypeId,
            string description, 
            decimal price)
        {
            CatalogItemId = Guid.NewGuid();
            SetName(name);
            EstablishmentId = establishmentId;
            Description = description;
            Price = price;
            CatalogTypeId = catalogTypeId;

            //ProductId = productId;
            //PictureFileName = pictureFileName;
            //PictureUri = pictureUri;
            //CatalogType = catalogType;
        }

        public void ChangeCatalogType(Guid catalogTypeId)
        {
            CatalogTypeId = catalogTypeId;
        }

        public void ChangeCatalogType(CatalogType catalogType)
        {
            CatalogTypeId = CatalogType;
        }


        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            Name = name;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
            {
                throw new ArgumentException("Price must be greater than zero.");
            }
            Price = newPrice;
        }

        public void ChangePictureUri(string uri)
        {
            PictureUri = uri;
        }

        public void ChangeEstablishment(Guid establishmentId)
        {
            EstablishmentId = establishmentId;
        }

    }
}
