using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemsByEstablishmentd
{
    public class GetCatalogItemsByEstablishmentdQuery : IRequest<Result<List<CatalogItemDto>>>
    {
        public Guid EstablishmentId { get; set; }

        public GetCatalogItemsByEstablishmentdQuery(Guid establishmentId)
        {
            EstablishmentId = establishmentId;  
        }
    }
}
