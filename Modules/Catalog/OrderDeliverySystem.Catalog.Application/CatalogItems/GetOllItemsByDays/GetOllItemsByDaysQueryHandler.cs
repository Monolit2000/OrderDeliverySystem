using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
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

            //var outList = root
            // .Where(p => request.ListOfDays.Contains(p.TimeToItemExist))

            // .ToList();
            var filteredDays = request.ListOfDays.Select(day => day.Date).ToList();



            var itemsByDays = root
            .Where(item => filteredDays.Contains(item.TimeToItemExist.Date))
            .GroupBy(item => item.TimeToItemExist.Date)
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




            //var itemsByDays = root
            //.GroupBy(item => item.TimeToItemExist.Date)
            //.Select(group => new ItemsByDaysDto
            //{
            //    Day = group.Key,
            //    Items = group.Select(item => new CatalogItemDto
            //    {
            //        Name = item.Name,
            //        Price = item.Price,
            //        Description = item.Description
            //    }).ToList()
            //})
            //.ToList();

            return itemsByDays;    
        }
    }
}
