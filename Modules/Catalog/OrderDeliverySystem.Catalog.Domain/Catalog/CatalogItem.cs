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

        public Guid CatalogItemId { get; private set; }

        [Required]
        public string Name { get; private set; }

        public DateTime TimeToItemExist {get; private set;}

        public Guid ProductId { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string PictureFileName { get; private set; } = string.Empty;

        public string PictureUri { get; private set; } = string.Empty;

        //public Guid EstablishmentId { get; private set; }

        //public Establishment Establishment { get; private set; }

        //public Guid CatalogTypeId { get; set; }

        //public CatalogType CatalogType { get; set; }


        private CatalogItem() 
        {

        }


        public CatalogItem(Guid id, string name, DateTime timeToItemExist, Guid productId, string description, decimal price, string pictureFileName, string pictureUri)
        {
            CatalogItemId = id;
            Name = name;
            TimeToItemExist = timeToItemExist;
            ProductId = productId;
            Description = description;
            Price = price;
            PictureFileName = pictureFileName;
            PictureUri = pictureUri;
        }


        //public CatalogItem(
        //   string name,
        //   Establishment establishment,
        //   string description,
        //   decimal price)
        //{
        //    CatalogItemId = Guid.NewGuid();
        //    SetName(name);
        //    Establishment = establishment;
        //    Description = description;
        //    Price = price;
        //}

        public CatalogItem(
            string name,
            DateTime timeToItemExist,
      //      Establishment establishment,
            string description,
            decimal price)
        {
            CatalogItemId = Guid.NewGuid();
            TimeToItemExist = timeToItemExist;  
            SetName(name);
    //        Establishment = establishment;
            Description = description;
            Price = price;
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


        public void ChangeTimeToItemExist(DateTime newDateTime)
        {
            TimeToItemExist = newDateTime;  
        }

        public void ChangePictureUri(string uri)
        {
            PictureUri = uri;
        }

        //public void ChangeEstablishment(Guid establishmentId)
        //{
        //    EstablishmentId = establishmentId;
        //}



        //public CatalogItem( 
        //    string name,
        //    Establishment establishment,
        //    CatalogType catalogType,
        //    string description, 
        //    decimal price)
        //{
        //    CatalogItemId = Guid.NewGuid();
        //    SetName(name);
        //    Establishment = establishment;
        //    Description = description;
        //    Price = price;
        //    CatalogType = catalogType;
        //}



        //public CatalogItem(
        //   string name,
        //   Guid establishmentId,
        //   Guid catalogTypeId,
        //   string description,
        //   decimal price)
        //{
        //    CatalogItemId = Guid.NewGuid();
        //    SetName(name);
        //    EstablishmentId = establishmentId;
        //    Description = description;
        //    Price = price;
        //    CatalogTypeId = catalogTypeId;
        //}


        //public void ChangeCatalogType(Guid catalogTypeId)
        //{
        //    CatalogTypeId = catalogTypeId;
        //}

        //public void ChangeCatalogType(CatalogType catalogType)
        //{
        //    CatalogType = catalogType;
        //}


    }
}
