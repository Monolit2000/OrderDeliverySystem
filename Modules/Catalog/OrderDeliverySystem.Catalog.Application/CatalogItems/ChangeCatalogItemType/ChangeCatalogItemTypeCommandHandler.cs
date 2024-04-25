using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<Result<ChangeCatalogItemDto>> Handle(ChangeCatalogItemTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
