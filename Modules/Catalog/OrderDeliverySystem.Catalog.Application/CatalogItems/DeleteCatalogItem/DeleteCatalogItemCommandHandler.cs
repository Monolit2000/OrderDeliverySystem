using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.DeleteCatalogItem
{
    public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand, Result<DeleteCatalogItemDto>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public DeleteCatalogItemCommandHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<DeleteCatalogItemDto>> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
        {

            var result = await _catalogRepository.RemoveCatalogItemByIdAsync(request.CatalogItemId);

            if (!result)
                return Result.Fail("Item not found");

            var deleteCatalogItemDto = new DeleteCatalogItemDto() {CatalogItemId = request.CatalogItemId };

            return deleteCatalogItemDto;
        }
    }
}
