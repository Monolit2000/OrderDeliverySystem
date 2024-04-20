using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystem.UserAccess.Application.Authentication;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Domain.Users;

namespace OrderDeliverySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessUserController : ControllerBase
    {
        private readonly IUserAccessModule _userAccessModule;

        public AccessUserController(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }


        [HttpPost(Name = "Activate User")]
        public async Task<IActionResult> UserActivation(ActivateUserRequest activateRequest)
        {
            var user = await _userAccessModule.ExecuteQueryAsync(new ActivateUserCommand(
                PhoneNumber.Create(activateRequest.PhoneNumber).Value, activateRequest.ChatId));

            return Ok(user);
        }
    }
}
