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

        public Establishment Establishment { get; private set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        public int CatalogTypeId { get; set; }

        public CatalogType CatalogType { get; set; }


        private CatalogItem() 
        {

        }    


        public CatalogItem( 
            string name,
            Guid productId,
            Establishment establishment, 
            string description, 
            decimal price, 
            string pictureFileName, 
            string pictureUri, 
            int catalogTypeId, 
            CatalogType catalogType)
        {
            CatalogItemId = Guid.NewGuid();
            SetName(name);
            ProductId = productId;
            Establishment = establishment;
            Description = description;
            Price = price;
            PictureFileName = pictureFileName;
            PictureUri = pictureUri;
            CatalogTypeId = catalogTypeId;
            CatalogType = catalogType;
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

        public void ChangeEstablishment(Establishment establishment)
        {
            Establishment = establishment;
        }

    }
}
