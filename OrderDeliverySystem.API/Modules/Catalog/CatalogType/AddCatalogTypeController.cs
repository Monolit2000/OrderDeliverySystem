//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using OrderDeliverySystem.API.Modules.Catalog.Establishment;
//using OrderDeliverySystem.Catalog.Application.CatalogTypes.AddCatalogType;
//using OrderDeliverySystem.Catalog.Application.CatalogTypes.GetAllCatalogTypes;
//using OrderDeliverySystem.Catalog.Application.Establishments.AddEstablishment;

//namespace OrderDeliverySystem.API.Modules.Catalog.CatalogType
//{
//    [Route("api/Catalog/CatalogType")]
//    [ApiController]
//    public class AddCatalogTypeController : ControllerBase 
//    {

//        private readonly IMediator _mediator;

//        public AddCatalogTypeController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpPost("AddCatalogType")]
//        public async Task<IActionResult> AddEstablishment(AddCatalogTypeRequest request)
//        {
//            var result = await _mediator.Send(new AddCatalogTypeCommand(request.Type));

//            if (!result.IsSuccess)
//            {
//                return BadRequest(result.Reasons);
//            }

//            return Ok(result.Value);
//        }


//        [HttpPost("GetOllCatalogTypes")]
//        public async Task<IActionResult> GetOllCatalogTypes()
//        {
//            var result = await _mediator.Send(new GetOllCatalogTypeQuery());

//            if (!result.IsSuccess)
//            {
//                return BadRequest(result.Reasons);
//            }

//            return Ok(result.Value);
//        }

//    }
//}
