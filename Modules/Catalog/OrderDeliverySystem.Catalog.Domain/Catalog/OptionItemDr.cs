using FluentResults;
using OrderDeliverySystem.CommonModule.Domain;


namespace OrderDeliverySystem.Catalog.Domain.Catalog
{
    public class OptionItemDr : Entity
    {
        public Guid OptionItemId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; } = string.Empty;

        private OptionItemDr() { } // For EF Core

        public OptionItemDr(
            Guid optionItemId,
            string name,
            string description,
            decimal price,
            string pictureUri)
        {
            OptionItemId = optionItemId;
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
        }

        public Result ChangeName(string name)
        {
            Name = name;
            return Result.Ok();
        }

        public Result ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                return Result.Fail("Price must be greater than zero.");

            Price = newPrice;
            return Result.Ok();
        }

        public Result ChangeDescription(string newDescription)
        {
            Description = newDescription;
            return Result.Ok();
        }

        public Result ChangePictureUri(string uri)
        {
            PictureUri = uri;
            return Result.Ok();
        }
    }
}
