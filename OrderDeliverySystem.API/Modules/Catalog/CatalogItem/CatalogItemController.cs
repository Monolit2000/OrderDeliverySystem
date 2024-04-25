using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Controllers;
using OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem;
using OrderDeliverySystem.Catalog.Application.CatalogItems.ChangeCatalogItemType;
using OrderDeliverySystem.Catalog.Application.CatalogItems.DeleteCatalogItem;
using OrderDeliverySystem.UserAccess.Application.Contracts;

namespace OrderDeliverySystem.API.Modules.Catalog.CatalogItem
{
    [Route("api/Catalog/CatalogItem")]
    [ApiController]
    public class CatalogItemController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CatalogItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddCatalogItem")]
        public async Task<IActionResult> AddCatalogItem(AddCatalogItemCommand addCatalogItemRequest)
        {
           var result = await _mediator.Send(addCatalogItemRequest);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }


        [HttpPut("ChangeCatalogItemType")]
        public async Task<IActionResult> ChangeCatalogItemType(ChangeCatalogItemTypeCommand changeCatalogItemType)
        {
            var result = await _mediator.Send(changeCatalogItemType);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpDelete("DeleteCatalogItem")]
        public async Task<IActionResult> ChangeCatalogItemType(DeleteCatalogItemCommand deleteCatalogItemCommand)
        {
            var result = await _mediator.Send(deleteCatalogItemCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

    }
}
