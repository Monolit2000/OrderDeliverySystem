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
    public class AddCatalogItemCommandHendler : IRequestHandler<AddCatalogItemCommand, Result<SmallCatalogItemDto>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogItemCommandHendler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<SmallCatalogItemDto>> Handle(AddCatalogItemCommand request, CancellationToken cancellationToken)
        {

            //var catalogType = await _catalogRepository.GetCatalogTypeByIdAsync(request.CatalogTypeId);

            //if (catalogType == null)
            //    return Result.Fail("Catalog type not found");

            //var establishment = await _catalogRepository.GetEstablishmentById(request.EstablishmentId);

            //if(establishment == null)
            //    return Result.Fail("Establishment not found");


            var catalogItem = new CatalogItem(
                request.Name,
                request.TimeToExist,
           //     establishment,
                request.Description,
                request.Price);

            await _catalogRepository.AddCatalogItemAsync(catalogItem);

            var catalogItemDto = new SmallCatalogItemDto(
                catalogItem.CatalogItemId, 
                catalogItem.Name);

            return Result.Ok(catalogItemDto);

        }

    }
}
