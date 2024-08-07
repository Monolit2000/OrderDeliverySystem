using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Application.Contract;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.UploadCatalogItemPhoto
{
    public class UploadCatalogItemPhotoCommandHandler(
        IBlobService blobService) : IRequestHandler<UploadCatalogItemPhotoCommand, Result<UploadPhotoResponce>>
    {
        public async Task<Result<UploadPhotoResponce>> Handle(UploadCatalogItemPhotoCommand request, CancellationToken cancellationToken)
        {
            var url = await blobService.UploadPhotoAsync(request.File);

            return new UploadPhotoResponce() {PhotoUrl = url };
        }
    }
}
