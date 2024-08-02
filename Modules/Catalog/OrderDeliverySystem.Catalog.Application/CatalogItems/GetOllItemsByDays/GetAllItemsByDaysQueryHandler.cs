using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.CommonModule.Infrastructure.Сache;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays
{
    public class GetAllItemsByDaysQueryHandler(
        ICatalogRepository _catalogRepository,
        IMemoryCache _cache
        /*IDistributedCache _cache*/) : IRequestHandler<GetAllItemsByDaysQuery, Result<List<ItemsByDaysDto>>>
    {
        public async Task<Result<List<ItemsByDaysDto>>> Handle(GetAllItemsByDaysQuery request, CancellationToken cancellationToken)
        {
             string key = $"catalog-all";

            //List<CatalogItem>? catalogItems = await _cache.GetOrCreateAsync(key, async token =>
            //     await _catalogRepository.GetAllCatalogItems(), 
            //     new DistributedCacheEntryOptions 
            //     {
            //         AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
            //     });

            //if (catalogItems is null)
            //    return Result.Fail("NULL");

            List<CatalogItem>? catalogItems = await _cache.GetOrCreateAsync(key, async token =>
               await _catalogRepository.GetAllCatalogItems(),
               new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) },
               cancellationToken);

            if (catalogItems is null)
                return Result.Fail("NULL");

            //var catalogItems = await _catalogRepository.GetAllCatalogItems();

            var itemsByDays = catalogItems
            .GroupBy(item => item.TimeToItemExist.Date)
            .OrderBy(g => g.Key)
            .Select(group => new ItemsByDaysDto
            {
                Day = group.Key,
                Items = group.Select(item => new CatalogItemDto
                {
                    Id = item.CatalogItemId,
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description
                }).ToList()
            }).ToList();

            return itemsByDays;
        }
    }
}
