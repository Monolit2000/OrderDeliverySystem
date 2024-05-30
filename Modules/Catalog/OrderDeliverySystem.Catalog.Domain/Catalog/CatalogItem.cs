using FluentResults;
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

        public string Name { get; private set; }

        public DateTime TimeToItemExist { get; private set; }

        public Guid ProductId { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string PictureFileName { get; private set; } = string.Empty;

        public string PictureUri { get; private set; } = string.Empty;


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


        public CatalogItem(
            string name,
            DateTime timeToItemExist,
            string description,
            decimal price)
        {
            CatalogItemId = Guid.NewGuid();
            TimeToItemExist = timeToItemExist;
            SetName(name);
            Description = description;
            Price = price;
        }



        public Result SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            Name = name;

            return Result.Ok();
        }

        public Result ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
            {
                return Result.Fail("Price must be greater than zero.");
            }
            Price = newPrice;

            return Result.Ok();
        }

        public Result ChangeDescription(string newDescription)
        {
            Description = newDescription;

            return Result.Ok();
        }


        public Result ChangeTimeToItemExist(DateTime newDateTime)
        {
            TimeToItemExist = newDateTime;

            return Result.Ok();
        }

        public Result ChangePictureUri(string uri)
        {
            PictureUri = uri;

            return Result.Ok();
        }


    }
}