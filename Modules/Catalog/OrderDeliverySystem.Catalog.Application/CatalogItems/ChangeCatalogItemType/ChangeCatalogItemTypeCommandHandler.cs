using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.ChangeCatalogItemType
{
    public class ChangeCatalogItemTypeCommandHandler : IRequestHandler<ChangeCatalogItemTypeCommand, Result<ChangeCatalogItemDto>>
    {

        private readonly ICatalogRepository _catalogRepository;

        public ChangeCatalogItemTypeCommandHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<ChangeCatalogItemDto>> Handle(ChangeCatalogItemTypeCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = await _catalogRepository.GetCatalogItemByIdAsync(request.CatalogItemId);

            var catalogType = await _catalogRepository.GetCatalogTypeByIdAsync(request.CatalogTypeId);

            //var oldType = catalogItem.CatalogType;

            //var oldType = await _catalogRepository.GetCatalogTypeByIdAsync(catalogItem.CatalogTypeId);

            if (catalogItem == null)
                return Result.Fail("Catalog Item not found");

            if (catalogType == null)
                return Result.Fail("Catalog type not found");

            //catalogItem.ChangeCatalogType(catalogType);

            await _catalogRepository.SaveChangesAsync();

            return new ChangeCatalogItemDto();

            //return new ChangeCatalogItemDto()
            //{
            //    OldTypeId = oldType.CatalogTypeId,
            //    OldType = oldType.Type,

            //    NewTypeId = catalogItem.CatalogTypeId,
            //    NewType = catalogType.Type
            //};
        }
    }
}
