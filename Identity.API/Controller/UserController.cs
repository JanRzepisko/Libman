using Identity.Application.Actions.Command.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace Identity.API.Controller;

[Route("User")]
public class UserController :BaseApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUser.Command command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok(ApiResponse.Success(200));
    }
}