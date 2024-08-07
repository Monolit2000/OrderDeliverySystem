using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Application.Contract;
using OrderDeliverySystem.Catalog.Application.Extensions;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.EditCatalogItem
{
    public class EditCatalogItemCommandHandler : IRequestHandler<EditCatalogItemCommand, Result<EditCatalogItemDto>>
    {
        private readonly IBlobService _blobService;

        private readonly ICatalogRepository _catalogRepository;

        public EditCatalogItemCommandHandler(
            IBlobService blobService,
            ICatalogRepository catalogRepository)
        {
            _blobService = blobService;
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<EditCatalogItemDto>> Handle(EditCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = await _catalogRepository.GetCatalogItemById(request.CatalogItemId);

            if (catalogItem == null)
                return Result.Fail("Catalog item not found");

            //if (request.photo != null)
            //    request.PictureUri = await _blobService.UploadPhotoAsync(request.photo);

            var results = new List<Result>
            {
                !string.IsNullOrWhiteSpace(request.Name)        ? catalogItem.SetName(request.Name) : Result.Ok(),
                request.TimeToItemExist != default              ? catalogItem.ChangeTimeToItemExist(request.TimeToItemExist) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.Description) ? catalogItem.ChangeDescription(request.Description) : Result.Ok(),
                request.Price > 0                               ? catalogItem.ChangePrice(request.Price) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.PictureUri)  ? catalogItem.ChangePictureUri(request.PictureUri) : Result.Ok()
            };

            var combinedResult = ResultExtension.CombineResults(results);

            if (combinedResult.IsFailed)
                return Result.Fail<EditCatalogItemDto>(combinedResult.Errors.First());


            if(request.OptionalItemName != null && 
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


            await _catalogRepository.SaveChangesAsync();

            return new EditCatalogItemDto();
        }
    }
}
