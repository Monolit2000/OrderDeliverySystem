using FluentResults;
using MediatR;
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
        public readonly ICatalogRepository _catalogRepository;

        public EditCatalogItemCommandHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<EditCatalogItemDto>> Handle(EditCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = await _catalogRepository.GetCatalogItemById(request.CatalogItemId);

            if (catalogItem == null)
                return Result.Fail("Catalog item not found");


            var results = new List<Result>
            {
                !string.IsNullOrWhiteSpace(request.Name)        ? catalogItem.SetName(request.Name) : Result.Ok(),
                request.TimeToItemExist != default              ? catalogItem.ChangeTimeToItemExist(request.TimeToItemExist) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.Description) ? catalogItem.ChangeDescription(request.Description) : Result.Ok(),
                request.Price > 0                               ? catalogItem.ChangePrice(request.Price) : Result.Ok(),
                !string.IsNullOrWhiteSpace(request.PictureUri)  ? catalogItem.ChangePictureUri(request.PictureUri) : Result.Ok()
            };


            var combinedResult = CombineResults(results);

            if (combinedResult.IsFailed)
                return Result.Fail<EditCatalogItemDto>(combinedResult.Errors.First());

            await _catalogRepository.SaveChangesAsync();

            return new EditCatalogItemDto();
        }

        private Result CombineResults(IEnumerable<Result> results)
        {
            foreach (var result in results)
            {
                if (result.IsFailed)
                    return result;
            }
            return Result.Ok();
        }
    }
}
