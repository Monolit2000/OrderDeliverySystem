using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Establishments.AddEstablishment
{
    public class AddEstablishmentCommandHandler : IRequestHandler<AddEstablishmentCommand, Result<AddEstablishmentDto>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public AddEstablishmentCommandHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<AddEstablishmentDto>> Handle(AddEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishmentExist = await _catalogRepository.GetEstablishmentByName(request.Name);

            if (establishmentExist != null)
                return Result.Fail("Establishment already exist");


            var establishment = Establishment.Create(request.Name);


            await _catalogRepository.AddEstablishmentAsync(establishment);


            var addEstablishmentDto = new AddEstablishmentDto
            {
                EstablishmentId = establishment.EstablishmentId,
                Name = establishment.Name
            };

            return Result.Ok(addEstablishmentDto);

          
        }
    }
}
