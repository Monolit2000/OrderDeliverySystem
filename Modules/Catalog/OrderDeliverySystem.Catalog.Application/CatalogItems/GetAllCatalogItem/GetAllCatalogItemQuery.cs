using FluentResults;
using MediatR;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItem
{
    public class GetAllCatalogItemQuery : IRequest<Result<List<CatalogItemDto>>>
    {
    }
}
