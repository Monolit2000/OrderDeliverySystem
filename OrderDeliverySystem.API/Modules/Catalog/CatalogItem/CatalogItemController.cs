using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem;
using OrderDeliverySystem.Catalog.Application.CatalogItems.ChangeCatalogItemType;
using OrderDeliverySystem.Catalog.Application.CatalogItems.DeleteCatalogItem;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemById;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetItemsByDays;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetOllItemsByDays;
using OrderDeliverySystem.API.Modules.Base;
using OrderDeliverySystem.Catalog.Application.CatalogItems.EditCatalogItem;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItem;
using OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItemByWeek;

namespace OrderDeliverySystem.API.Modules.Catalog.CatalogItem
{
    [Route("api/Catalog/CatalogItem")]
    [ApiController]
    public class CatalogItemController : BaseController
    {
        private readonly IMediator _mediator;

        public CatalogItemController(IMediator mediator) 
            => _mediator = mediator;
     

        [HttpPost("AddCatalogItem")]
        public async Task<IActionResult> AddCatalogItem(AddCatalogItemCommand addCatalogItemRequest)
        {
            return HandleResult(await _mediator.Send(addCatalogItemRequest));
        }


        [HttpPut("ChangeCatalogItemType")]
        public async Task<IActionResult> ChangeCatalogItemType(ChangeCatalogItemTypeCommand changeCatalogItemType)
        {
            return HandleResult(await _mediator.Send(changeCatalogItemType));
        }


        [HttpPost("DeleteCatalogItem")]
        public async Task<IActionResult> DeleteCatalogItem(DeleteCatalogItemCommand deleteCatalogItemCommand)
        {
            return HandleResult(await _mediator.Send(deleteCatalogItemCommand));
        }


        [HttpPost("GetItemsByDays")]
        public async Task<IActionResult> DeleteCatalogItem(GetItemsByDaysQuery getOllItemsByDaysQuery)
        {
            return HandleResult(await _mediator.Send(getOllItemsByDaysQuery));
        }


        [HttpGet("GetOllItemsByDays")]
        public async Task<IActionResult> GetOllItemsByDays()
        {
            return HandleResult(await _mediator.Send( new GetAllItemsByDaysQuery()));
        }


        [HttpGet("GetAllCatalogItemsByWeek")]
        public async Task<IActionResult> EditCatalogItem(/*GetAllCatalogItemsByWeekQuery getAllCatalogItemsByWeekQuery*/)
        {
            return HandleResult(await _mediator.Send(new GetAllCatalogItemsByWeekQuery()));
        }


        [HttpGet("GetAllCatalogItem")]
        public async Task<IActionResult> GetAllCatalogItem()
        {
            return HandleResult(await _mediator.Send(new GetAllCatalogItemQuery()));
        }

        [HttpPost("GetItemById")]
        public async Task<IActionResult> GetItemById(GetItemByIdQuerie getItemByIdQuerie)
        {
            return HandleResult(await _mediator.Send(getItemByIdQuerie));
        }


        [HttpPost("EditCatalogItem")]
        public async Task<IActionResult> EditCatalogItem(EditCatalogItemCommand editCatalogItemCommand)
        {
            return HandleResult(await _mediator.Send(editCatalogItemCommand));
        }

    }
}
