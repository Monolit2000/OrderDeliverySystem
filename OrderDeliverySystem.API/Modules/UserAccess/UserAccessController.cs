using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.API.Modules.Base;
using OrderDeliverySystem.UserAccess.Application.Authentication;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Application.Users.ChangeFirstName;
using OrderDeliverySystem.UserAccess.Application.Users.ChangeLastName;
using OrderDeliverySystem.UserAccess.Application.Users.ChangePhoneNumber;
using OrderDeliverySystem.UserAccess.Application.Users.CreateConsumer;
using OrderDeliverySystem.UserAccess.Application.Users.GetOllActiveConsumers;
using OrderDeliverySystem.UserAccess.Application.Users.GetUserByChatId;
using OrderDeliverySystem.UserAccess.Application.Users.UpdateUser;
using OrderDeliverySystem.UserAccess.Domain.Users;

namespace OrderDeliverySystem.API.Modules.UserAccess
{
    [Route("api/userAccess")]
    [ApiController]
    public class UserAccessController : BaseController
    {
        private readonly IUserAccessModule _userAccessModule;
        private readonly IMediator _mediator;

        public UserAccessController(
            IUserAccessModule userAccessModule, 
            IMediator mediator)
        {
            _userAccessModule = userAccessModule;
            _mediator = mediator;
        }


        [HttpPost("ActivateUser")]
        public async Task<IActionResult> UserActivation(ActivateUserRequest activateRequest)
        {

            var user = await _userAccessModule.ExecuteCommandAsync(
                new ActivateUserCommand(PhoneNumber.Create(activateRequest.PhoneNumber).Value,
                activateRequest.ChatId));

            return Ok(user);
        }


        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> CreateCustomer(CreateUserRequest createRequest)
        {

            return HandleResult(await _userAccessModule.ExecuteCommandAsync(
                new CreateConsumerCommand(PhoneNumber.Create(createRequest.PhoneNumber).Value,
                createRequest.FirstName,
                createRequest.LastName,
                createRequest.Name,
                createRequest.ChatId)));
        }


        [HttpGet("GetOllActiveUsers")]
        public async Task<IActionResult> GetOllActiveUsers()
        {
            return HandleResult(await _mediator.Send(new GetOllActiveUserQuerie()));
        }


        [HttpPut("ChangeFirstName")]
        public async Task<IActionResult> ChangeFirstName(ChangeFirstNameCommand changeFirstNameCommand)
        {
            return HandleResult(await _mediator.Send(changeFirstNameCommand));
        }


        [HttpPost("GetUserByChatId")]
        public async Task<IActionResult> GetUserByChatId(GetUserByChatIdQuerie getUserByChatIdQuerie)
        {
            return HandleResult(await _mediator.Send(getUserByChatIdQuerie));
        }


        [HttpPut("ChangeLastName")]
        public async Task<IActionResult> ChangeLastName(ChangeLastNameCommand changeLastNameCommand)
        {
            return HandleResult(await _mediator.Send(changeLastNameCommand));
        }
         

        [HttpPut("ChangePhoneNumber")]
        public async Task<IActionResult> ChangePhoneNumber(ChangePhoneNumberCommand changePhoneNumberCommand)
        {
            return HandleResult(await _mediator.Send(changePhoneNumberCommand));
        }


        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            return HandleResult(await _mediator.Send(updateUserCommand));
        }
    }
}
