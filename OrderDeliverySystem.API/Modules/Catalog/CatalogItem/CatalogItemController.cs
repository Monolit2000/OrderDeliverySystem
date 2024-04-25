using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Controllers;
using OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem;
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

        [HttpPost("AddType")]
        public async Task<IActionResult> AddCatalogItem(AddCatalogItemRequest addCatalogItemRequest)
        {
            await _mediator.Send(new AddCatalogItemCommand());

            return Ok();
        }

    }
}
