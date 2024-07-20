using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemsByDays;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using OrderDeliverySystem.CommonModule.Infrastructure.Сache;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays
{
    public class GetOllItemsByDaysQueryHandler : IRequestHandler<GetOllItemsByDaysQuery, Result<List<ItemsByDaysDto>>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IDistributedCache _cache;

        public GetOllItemsByDaysQueryHandler(
            ICatalogRepository catalogRepository,
            IDistributedCache cache)
        {
            _catalogRepository = catalogRepository;
            _cache = cache;
        }

        public async Task<Result<List<ItemsByDaysDto>>> Handle(GetOllItemsByDaysQuery request, CancellationToken cancellationToken)
        {
            string key = $"catalog-oll";

            List<CatalogItem>? catalogItems = await _cache.GetOrCreateAsync(key, async token =>
            {
                var catalogItems = await _catalogRepository.GetOllCatalogItems();
                return catalogItems;
            });


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
