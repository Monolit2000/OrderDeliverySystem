using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using FluentResults;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem
{
    public class AddCatalogCommandHendler : IRequestHandler<AddCatalogItemCommand, Result<CatalogItemDto>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogCommandHendler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<CatalogItemDto>> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
        {

            if (!await _catalogRepository.CatalogTypeExistByIdAsync(request.CatalogTypeId))
                return Result.Fail("The catalog type does not exist");

            if (!await _catalogRepository.EstablishmentExistByIdAsync(request.EstablishmentId))
                return Result.Fail("The Establishmen does not exist");


            var catalogItem = new CatalogItem(
                request.Name,
                request.EstablishmentId,
                request.CatalogTypeId,
                request.Description,
                request.Price);

            await _catalogRepository.AddCatalogItemAsync(catalogItem);

            var catalogItemDto = new CatalogItemDto(
                catalogItem.CatalogItemId, 
                catalogItem.Name);

            return Result.Ok(catalogItemDto);

        }

    }
}
