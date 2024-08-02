using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;


namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItemByWeek
{
    public class GetAllCatalogItemsByWeekQueryHandler(
        ICatalogRepository catalogItemRepository) : IRequestHandler<GetAllCatalogItemsByWeekQuery, Result<List<CatalogItemsByWeekDto>>>
    {
        public async Task<Result<List<CatalogItemsByWeekDto>>> Handle(GetAllCatalogItemsByWeekQuery request, CancellationToken cancellationToken)
        {
            var catalogItems = await catalogItemRepository.GetAllCatalogItems();

            var groupedByWeek = catalogItems
                .GroupBy(item => StartOfWeek(item.TimeToItemExist, DayOfWeek.Monday))
                .Select(group => new CatalogItemsByWeekDto
                {
                    WeekStart = group.Key,
                    WeekEnd = group.Key.AddDays(6),
                    CatalogItems = group.Select(item => new CatalogItemDto
                    {
                        CatalogItemId = item.CatalogItemId,
                        Name = item.Name,
                        TimeToItemExist = item.TimeToItemExist,
                        ProductId = item.ProductId,
                        Description = item.Description,
                        Price = item.Price,
                        PictureFileName = item.PictureFileName,
                        PictureUri = item.PictureUri
                    }).ToList()
                }).ToList();

            return Result.Ok(groupedByWeek);
        }

        private DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
