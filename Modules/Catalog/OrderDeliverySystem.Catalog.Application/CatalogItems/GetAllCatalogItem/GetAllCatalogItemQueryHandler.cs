using FluentResults;
using MediatR;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItem
{
    public class GetAllCatalogItemQueryHandler(ICatalogRepository catalogRepository) : IRequestHandler<GetAllCatalogItemQuery, Result<List<CatalogItemDto>>>
    {
        public async Task<Result<List<CatalogItemDto>>> Handle(GetAllCatalogItemQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var catalogItems = await catalogRepository.GetAllCatalogItems();

                var catalogItemDtos = catalogItems.Select(item => new CatalogItemDto
                {
                    Id = item.CatalogItemId,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    PictureUri = item.PictureUri,
                    Deadline = DateOnly.FromDateTime(item.TimeToItemExist)
                }).ToList();

                return catalogItemDtos;
            }
            catch (Exception ex)
            {
                return Result.Fail<List<CatalogItemDto>>($"Error retrieving catalog items: {ex.Message}");
            }


        }
    }
}
