using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.CommonModule.Infrastructure.Сache;


namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays
{
    public class GetOllItemsByDaysQueryHandler(
        ICatalogRepository _catalogRepository,
        IDistributedCache _cache) : IRequestHandler<GetOllItemsByDaysQuery, Result<List<ItemsByDaysDto>>>
    {
        //private readonly ICatalogRepository _catalogRepository;
        //private readonly IDistributedCache _cache;

        //public GetOllItemsByDaysQueryHandler(
        //    ICatalogRepository catalogRepository,
        //    IDistributedCache cache)
        //{
        //    _catalogRepository = catalogRepository;
        //    _cache = cache;
        //}

        public async Task<Result<List<ItemsByDaysDto>>> Handle(GetOllItemsByDaysQuery request, CancellationToken cancellationToken)
        {
            string key = $"catalog-oll";

            //if (!_cache.TryGetValue(key, out List<CatalogItem>? catalogItems))
            //{ 
            //    catalogItems = await _catalogRepository.GetOllCatalogItems();
            //    if (catalogItems != null)
            //    {
            //        _cache.Set(key, catalogItems, TimeSpan.FromHours(1)); // Set the cache expiration as needed
            //    }
            //}

            List<CatalogItem>? catalogItems = await _cache.GetOrCreateAsync(key, async token =>
                 await _catalogRepository.GetOllCatalogItems());

            if (catalogItems is null)
                return Result.Fail("NULL");

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
