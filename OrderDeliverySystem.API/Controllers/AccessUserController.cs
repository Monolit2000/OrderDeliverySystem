using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.Basket.Application.Basket.CreateBasket;
using OrderDeliverySystem.Catalog.Application.AddCatalog;
using OrderDeliverySystem.UserAccess.Application.Authentication;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer;
using OrderDeliverySystem.UserAccess.Domain.Users;

namespace OrderDeliverySystem.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccessUserController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;
        private readonly IMediator _mediator;

        public AccessUserController(IUserAccessModule userAccessModule, IMediator mediator)
        {
            _userAccessModule = userAccessModule;
            _mediator = mediator;
        }


        [HttpPost("ActivateUser")]
        public async Task<IActionResult> UserActivation(ActivateUserRequest activateRequest)
        {
            //var user = await _mediator.Send(new ActivateUserCommand(
            //    PhoneNumber.Create(activateRequest.PhoneNumber).Value,
            //    activateRequest.ChatId));

            var user = await _userAccessModule.ExecuteCommandAsync(
                new ActivateUserCommand(PhoneNumber.Create(activateRequest.PhoneNumber).Value,
                activateRequest.ChatId));

            return Ok(user);
        }

        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> CreateCustomer(CreateUserRequest createRequest)
        {
            //var user = await _mediator.Send(new CreateConsumerCommand(
            //    PhoneNumber.Create(createRequest.PhoneNumber).Value,
            //    createRequest.FirstName,
            //    createRequest.LastName,
            //    createRequest.Name));

            var user = await _userAccessModule.ExecuteCommandAsync(
                new CreateConsumerCommand(PhoneNumber.Create(createRequest.PhoneNumber).Value,
                createRequest.FirstName,
                createRequest.LastName,
                createRequest.Name,
                createRequest.ChatId));

            return Ok(user);
        }

        [HttpPost("AddType")]
        public async Task<IActionResult> CreateCatalogType(ActivateUserRequest activateRequest)
        {
            await _mediator.Send(new AddCatalogCommand());

            return Ok();
        }


        [HttpPost("AddBasket")]
        public async Task<IActionResult> CreateBusket(ActivateUserRequest activateRequest)
        {
            await _mediator.Send(new CreateBasketCommand(Guid.NewGuid(), activateRequest.ChatId));

            return Ok();
        }


        

    }

}
