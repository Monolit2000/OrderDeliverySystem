using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemsByDays;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays
{
    public class GetOllItemsByDaysQueryHandler : IRequestHandler<GetOllItemsByDaysQuery, Result<List<ItemsByDaysDto>>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public GetOllItemsByDaysQueryHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<Result<List<ItemsByDaysDto>>> Handle(GetOllItemsByDaysQuery request, CancellationToken cancellationToken)
        {
            var root = await _catalogRepository.GetOllCatalogItems();

            var itemsByDays = root
            .GroupBy(item => item.TimeToItemExist.Date)
            .OrderBy(g => g.Key)
            .Select(group => new ItemsByDaysDto
            {
                Day = group.Key,
                Items = group.Select(item => new CatalogItemDto
                {
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description
                }).ToList()
            })
            .ToList();

            return itemsByDays;
        }
    }
}
