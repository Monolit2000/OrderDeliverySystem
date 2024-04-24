using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogTypes.AddCatalogType
{
    public class AddCatalogTypeCommandHandler : IRequestHandler<AddCatalogTypeCommand, Result<CatalogTypeDto>>
    {

        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogTypeCommandHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }


        public async Task<Result<CatalogTypeDto>> Handle(AddCatalogTypeCommand request, CancellationToken cancellationToken)
        {

            //if (!await _catalogRepository.CatalogTypeExistByIdAsync(request.CatalogTypeId))
            //    return Result.Fail("The catalog type does not exist");

            var cutalogItem = new CatalogType(request.Type);
            

            await _catalogRepository.AddCatalogTypeAsync(cutalogItem);

            var catalogTypeDto = new CatalogTypeDto(
                cutalogItem.CatalogTypeId,
                cutalogItem.Type);

            return catalogTypeDto;
        }

    }
}
