using Eparafia.Application.Actions.Parish;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace Library.API.Controllers;

[ApiController]
[Authorize("Admin")]
[Route("User")]
public class UserController : BaseApiController
{
    public UserController(IMediator mediator) : base(mediator){}
    
    [HttpGet]
    public Task<IActionResult> Endpoint(int page) => base.Endpoint(new GetUsers.Command(page));
}