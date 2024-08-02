using FluentResults;
using MediatR;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItemByWeek
{
    public class GetAllCatalogItemsByWeekQuery : IRequest<Result<List<CatalogItemsByWeekDto>>>
    {
    }
}
