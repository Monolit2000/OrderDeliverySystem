using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Application.Establishments.GetOllEstablishment;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogTypes.GetAllCatalogTypes
{
    public class GetOllCatalogTypeQueryHandler : IRequestHandler<GetOllCatalogTypeQuery, Result<List<CatalogTypeDto>>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public GetOllCatalogTypeQueryHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<List<CatalogTypeDto>>> Handle(GetOllCatalogTypeQuery request, CancellationToken cancellationToken)
        {
            var ollCatalogTypes = await _catalogRepository.GetOllCatalogTypeAsync();

            if (ollCatalogTypes == null || !ollCatalogTypes.Any())
                return Result.Fail("The list of establishments is empty");

            var ollCatalogTypesDto = ollCatalogTypes.Select(ct => new CatalogTypeDto
            {
                CatalogTypeId = ct.CatalogTypeId,
                Type = ct.Type
            }).ToList();

            return ollCatalogTypesDto;

        }
    }
}
