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
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost("Register")]
    public Task<IActionResult> Endpoint(RegisterUser.Command request) => base.Endpoint(request);    
    
    [HttpPost("Login")]
    public Task<IActionResult> Endpoint(LoginUser.Command request) => base.Endpoint(request);
    
    [Authorize]
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateUser.Command request) => base.Endpoint(request);
    
    [Authorize]
    [HttpDelete]
    public Task<IActionResult> Endpoint(RemoveUser.Command request) => base.Endpoint(request);

}