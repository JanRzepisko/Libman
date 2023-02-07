using Identity.Application.Actions.Command.Admin;
using Identity.Application.Actions.Query.Admin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace Identity.API.Controller;

[ApiController]
[Route("Admin")]
public class AdminController : BaseApiController
{
    public AdminController(IMediator mediator) : base(mediator) { }

    [HttpPost("Register")]
    public Task<IActionResult> Endpoint(RegisterAdmin.Command request) => base.Endpoint(request);    
    
    [HttpPost("Login")]
    public Task<IActionResult> Endpoint(LoginAdmin.Command request) => base.Endpoint(request);
    
    [Authorize]
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateAdmin.Command request) => base.Endpoint(request);
    
    [Authorize]
    [HttpDelete]
    public Task<IActionResult> Endpoint(RemoveAdmin.Command request) => base.Endpoint(request);

}