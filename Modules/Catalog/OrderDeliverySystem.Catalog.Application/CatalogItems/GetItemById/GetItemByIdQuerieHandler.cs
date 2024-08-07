using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemById
{
    public class GetItemByIdQuerieHandler : IRequestHandler<GetItemByIdQuerie, Result<CatalogItemDto>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public GetItemByIdQuerieHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<CatalogItemDto>> Handle(GetItemByIdQuerie request, CancellationToken cancellationToken)
        {
            var catalogItem = await _catalogRepository.GetCatalogItemByIdAsync(request.ItemId);

            if (catalogItem == null)
                return Result.Fail("Catalog Item not found");

            var catalogItemDto = new CatalogItemDto
            {
                ItemId = catalogItem.CatalogItemId,
                Name = catalogItem.Name,
                Description = catalogItem.Description,
                Price = catalogItem.Price,
                Day = catalogItem.TimeToItemExist,
                ImageUri = catalogItem.PictureUri,
                OptionalItemName = catalogItem.OptionItem.Name,
                OptionalItemDescription = catalogItem.OptionItem.Description,
                OptionalItemPrice = catalogItem.OptionItem.Price
            };

            return catalogItemDto;
        }
    }
}
