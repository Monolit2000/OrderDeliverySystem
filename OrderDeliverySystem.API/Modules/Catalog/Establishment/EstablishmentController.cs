using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Controllers;
using OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem;
using OrderDeliverySystem.Catalog.Application.Establishments.AddEstablishment;

namespace OrderDeliverySystem.API.Modules.Catalog.Establishment
{

    [Route("api/Establishment")]
    [ApiController]
    public class EstablishmentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EstablishmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddEstablishment")]
        public async Task<IActionResult> AddEstablishment(AddEstablishmentRequest addEstablishmentRequest)
        {
            var result = await _mediator.Send(new AddEstablishmentCommand(addEstablishmentRequest.Name));

            return Ok(result);
        }
    }
}
