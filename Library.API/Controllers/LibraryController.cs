using Library.Application.Actions.Library;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace Library.API.Controllers;

[ApiController]
[Authorize("Admin")]
[Route("Library")]
public class LibraryController : BaseApiController
{
    public LibraryController(IMediator mediator) : base(mediator){}
    
    [HttpPost]
    public Task<IActionResult> Endpoint(CreateLibrary.Command request) => base.Endpoint(request);        
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateLibrary.Command request) => base.Endpoint(request);        
    [HttpDelete]
    public Task<IActionResult> Endpoint(RemoveLibrary.Command request) => base.Endpoint(request);        
    [HttpGet]
    public Task<IActionResult> Endpoint(GetById.Query request) => base.Endpoint(request);
}