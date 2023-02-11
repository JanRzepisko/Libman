using Book.Application.Actions.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;
using Shared.BaseModels.Jwt;

namespace Book.API.Controllers;

[Authorize(JwtPolicies.Admin)]
[ApiController]
[Route("Book")]
public class BookController : BaseApiController
{
    public BookController(IMediator mediator) : base(mediator) { }
    
    [HttpPost]
    public Task<IActionResult> Endpoint(CreateBook.Command request) => base.Endpoint(request);        
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateBook.Command request) => base.Endpoint(request);        
    [HttpDelete]
    public Task<IActionResult> Endpoint(RemoveBook.Command request) => base.Endpoint(request);    
    [HttpGet]
    public Task<IActionResult> Endpoint(string searchString, int page, Guid LibraryId) => base.Endpoint(new GetBook.Command(searchString, page, LibraryId));    
    
}