using Identity.Application.Actions.Command.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;
using Shared.BaseModels.Jwt;

namespace Identity.API.Controller;

[ApiController]
[Authorize(JwtPolicies.Admin)]
[Route("User")]
public class UserController : BaseApiController
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost("Register")]
    public Task<IActionResult> Endpoint(CreateUser.Command request) => base.Endpoint(request);

    [Authorize]
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateUser.Command request) => base.Endpoint(request);
    
    [Authorize]
    [HttpDelete]
    public Task<IActionResult> Endpoint(RemoveUser.Command request) => base.Endpoint(request);

}