using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using FluentResults;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem
{
    public class AddCatalogItemCommandHendler : IRequestHandler<AddCatalogItemCommand, Result<SmallCatalogItemDto>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogItemCommandHendler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<SmallCatalogItemDto>> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var catalogItemResult = CatalogItem.CreateNew(
                request.Name,
                request.TimeToExist,
                request.Description,
                request.Price,
                pictureUri: request.PictureUrl);
             
            if(catalogItemResult.IsFailed)
                return Result.Fail(catalogItemResult.Errors);

            var catalogItem = catalogItemResult.Value;

            await _catalogRepository.AddCatalogItemAsync(catalogItem);

            var catalogItemDto = new SmallCatalogItemDto(
                catalogItem.CatalogItemId, 
                catalogItem.Name);

            return Result.Ok(catalogItemDto);
        }
    }
}
