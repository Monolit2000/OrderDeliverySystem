using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;

namespace OrderDeliverySystem.Catalog.Application.AddCatalog
{
    public class AddCatalogCommandHendler : IRequestHandler<AddCatalogCommand>
    {
        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogCommandHendler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task Handle(AddCatalogCommand request, CancellationToken cancellationToken)
        {
            var cutalogItem = new CatalogType()
            {
              
                Type = "test"
            };

            await _catalogRepository.AddCatalogItemAsync(cutalogItem);
        }
    }
}
