using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.UserAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.IntegrationEvents
{
    public class CatalogItemAddIntegretionEventHandler : INotificationHandler<CatalogItemAddIntegretionEvent>
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogItemAddIntegretionEventHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task Handle(CatalogItemAddIntegretionEvent notification, CancellationToken cancellationToken)
        {
           

        }
    }
}
