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

            if (catalogItem == null)
                return Result.Fail("Item not found");

            if (catalogType == null)
                return Result.Fail("Item not found");

            catalogItem.ChangeCatalogType(catalogType);

            await _catalogRepository.SaveChangesAsync();
            //CatalogItem

            throw new NotImplementedException();
        }
    }
}
