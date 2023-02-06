using Identity.Application.Actions.Command.User;
using Identity.Application.Actions.Query.User;
using Identity.Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.ApiControllerModels;

namespace Identity.API.Controller;

[ApiController]
[Route("User")]
public class UserController : BaseApiController
{

    [AllowAnonymous]
    [HttpPost("Register")]
    public Task<IActionResult> Endpoint(RegisterUser.Command request, CancellationToken ct) => base.Endpoint(request, ct);

    [AllowAnonymous]
    [HttpPost("Login")]
    public Task<IActionResult> Endpoint(LoginUser.Command request, CancellationToken ct) => base.Endpoint(request, ct);
    
    [Authorize]
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateUser.Command request, CancellationToken ct) => base.Endpoint(request, ct);

    public UserController(IMediator mediator) : base(mediator) { }
}