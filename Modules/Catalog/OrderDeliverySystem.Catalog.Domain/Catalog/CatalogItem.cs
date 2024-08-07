using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;
using OrderDeliverySystem.Catalog.Domain.Catalog.Events;

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

        public OptionItem OptionItem { get; private set; }

        //public OptionItemDr? OptionItemDr { get; private set; }

        private CatalogItem() { } // For EF Core

        public CatalogItem(
            Guid catalogItemId,
            string name,
            DateTime timeToItemExist,
            Guid productId,
            string description,
            decimal price,
            string pictureFileName,
            string pictureUri)
        {
            CatalogItemId = catalogItemId;
            Name = name;
            TimeToItemExist = timeToItemExist;
            ProductId = productId;
            Description = description;
            Price = price;
            PictureFileName = pictureFileName;
            PictureUri = pictureUri;
            OptionItem = new OptionItem();

            AddDomainEvent(new CatalogItemCreatedDomainEvent());
        }

        public static Result<CatalogItem> CreateNew(
            string name,
            DateTime timeToItemExist,
            string description,
            decimal price,
            string pictureFileName = "",
            string pictureUri = "")
        {
            if (price <= 0)
                return Result.Fail<CatalogItem>("Price must be greater than zero.");

            if (string.IsNullOrEmpty(pictureUri))
                return Result.Fail("Picture URL is required");

            var catalogItem = new CatalogItem
            {
                CatalogItemId = Guid.NewGuid(),
                Name = name,
                TimeToItemExist = timeToItemExist,
                Description = description,
                Price = price,
                PictureFileName = pictureFileName,
                PictureUri = pictureUri,
            };
            return Result.Ok(catalogItem);
        }

        public Result SetName(string name)
        {
            Name = name;
            return Result.Ok();
        }

        public Result ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                return Result.Fail("Price must be greater than zero.");

            Price = newPrice;
            AddDomainEvent(new CatalogItemPriceChangedDomainEvent());
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
            AddDomainEvent(new TimeToItemExistChangedDomainEvent());
            return Result.Ok();
        }

        public Result ChangePictureUri(string uri)
        {
            PictureUri = uri;
            AddDomainEvent(new CatalogItemPictureChangedDomainEvent());
            return Result.Ok();
        }

        public Result AddOptionItem(OptionItem optionItem)
        {
            OptionItem = optionItem;

            AddDomainEvent(new OptionItemAddedDomainEvent());
            return Result.Ok();
        }
    }
}
