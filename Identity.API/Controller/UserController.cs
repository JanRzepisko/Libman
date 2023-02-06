using Identity.Application.Actions.Command.User;
using Identity.Application.Actions.Query.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace Identity.API.Controller;

[ApiController]
[Route("User")]
public class UserController : BaseApiController
{

    [AllowAnonymous]
    [HttpPost("Register")]
    public Task<IActionResult> Endpoint(RegisterUser.Command request) => base.Endpoint(request);

    [AllowAnonymous]
    [HttpPost("Login")]
    public Task<IActionResult> Endpoint(LoginUser.Command request) => base.Endpoint(request);
    
    [Authorize]
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateUser.Command request) => base.Endpoint(request);

    public UserController(IMediator mediator) : base(mediator) { }
}