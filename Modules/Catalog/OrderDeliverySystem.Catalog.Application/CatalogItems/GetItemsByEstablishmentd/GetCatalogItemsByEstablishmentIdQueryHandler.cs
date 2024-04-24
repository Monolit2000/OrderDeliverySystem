using Autofac.Core;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemsByEstablishmentd
{
    public class GetCatalogItemsByEstablishmentIdQueryHandler : IRequestHandler<GetCatalogItemsByEstablishmentdQuery, Result<List<CatalogItemDto>>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public GetCatalogItemsByEstablishmentIdQueryHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<List<CatalogItemDto>>> Handle(GetCatalogItemsByEstablishmentdQuery request, CancellationToken cancellationToken)
        {
            var root = _catalogRepository.GetOllCatalogItemQueryable();

            root = root.Where(ci => ci.EstablishmentId == request.EstablishmentId);

            if (!root.Any())
                return Result.Fail("No products found");

            var catalogItems = await root.ToListAsync(cancellationToken);

            var catalogItemDtos = catalogItems.Select(ci => new CatalogItemDto
            {
                Id = ci.CatalogItemId,
                Name = ci.Name,
                Description = ci.Description,
                ImageUri = ci.PictureFileName, 
                Price = ci.Price,
                PictureUri = ci.PictureUri
            }).ToList();

            return Result.Ok(catalogItemDtos);
        }

    }
}
