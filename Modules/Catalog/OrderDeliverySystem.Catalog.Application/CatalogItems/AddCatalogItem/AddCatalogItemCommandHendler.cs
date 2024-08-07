using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using FluentResults;
using OrderDeliverySystem.Catalog.Application.Contract;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem
{
    public class AddCatalogItemCommandHendler : IRequestHandler<AddCatalogItemCommand, Result<SmallCatalogItemDto>>
    {
        private readonly IBlobService _blobService;

        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogItemCommandHendler(
            IBlobService blobService,
            ICatalogRepository catalogRepository)
        {
            _blobService = blobService;
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<SmallCatalogItemDto>> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
        {
            //if (request.photo != null)
            //    request.PictureUrl = await _blobService.UploadPhotoAsync(request.photo); 

            var catalogItemResult = CatalogItem.CreateNew(
                request.Name,
                request.TimeToExist,
                request.Description,
                request.Price,
                pictureUri: request.PictureUrl);
             
            if(catalogItemResult.IsFailed)
                return Result.Fail(catalogItemResult.Errors);

            var catalogItem = catalogItemResult.Value;

            if (request.OptionalItemName != null &&
             request.OptionalItemDescription != null &&
             request.OptionalItemPrice != default)
            {
                catalogItem.AddOptionItem(new OptionItem(
                    request.OptionalItemName,
                    request.OptionalItemDescription,
                    request.OptionalItemPrice));
            }
            else
            {
                catalogItem.AddOptionItem(new OptionItem());
            }

            await _catalogRepository.AddCatalogItemAsync(catalogItem);

            var catalogItemDto = new SmallCatalogItemDto(
                catalogItem.CatalogItemId, 
                catalogItem.Name);

            return Result.Ok(catalogItemDto);
        }
    }
}
