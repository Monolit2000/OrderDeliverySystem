using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Catalog.Application.CatalogItems.AddCatalogItem;
using OrderDeliverySystem.Catalog.Application.Establishments.AddEstablishment;
using OrderDeliverySystem.Catalog.Application.Establishments.GetOllEstablishment;

namespace OrderDeliverySystem.API.Modules.Catalog.Establishment
{

    [Route("api/Catalog/Establishment")]
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

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }


        [HttpPost("GetOllEstablishment")]
        public async Task<IActionResult> GetOllEstablishment(/*GetOllEstablishmentRequest getOllEstablishmentRequest*/)
        {
            var result = await _mediator.Send(new GetOllEstablishmentQuery());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

   

        

    }
}
