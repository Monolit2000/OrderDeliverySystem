using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Establishments.GetOllEstablishment
{
    public class GetOllEstablishmentQueryHandler : IRequestHandler<GetOllEstablishmentQuery, Result<List<SmallEstablishmentDto>>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public GetOllEstablishmentQueryHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<List<SmallEstablishmentDto>>> Handle(GetOllEstablishmentQuery request, CancellationToken cancellationToken)
        {
            var ollEstablishments = await _catalogRepository.GetOllEstablishment();

            if (ollEstablishments == null || !ollEstablishments.Any())
                return Result.Fail("The list of establishments is empty");

            var ollEstablishmentsDto = ollEstablishments.Select(e => new SmallEstablishmentDto
            {
                EstablishmentId = e.EstablishmentId,
                Name = e.Name
            }).ToList();

            return ollEstablishmentsDto;
        }
    }
}
