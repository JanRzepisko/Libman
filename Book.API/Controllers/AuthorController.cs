using Book.Application.Actions.Author;
using Book.Application.Actions.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;
using Shared.BaseModels.Jwt;

namespace Book.API.Controllers;

[Authorize(JwtPolicies.Admin)]
[ApiController]
[Route("Author")]
public class AuthorController : BaseApiController
{
    public AuthorController(IMediator mediator) : base(mediator) { }
    
    [HttpPost]
    public Task<IActionResult> Endpoint(CreateAuthor.Command request) => base.Endpoint(request);        
    [HttpPut]
    public Task<IActionResult> Endpoint(UpdateAuthor.Command request) => base.Endpoint(request); 
    [HttpGet]
    public Task<IActionResult> Endpoint(string query, int page) => base.Endpoint(new SearchAuthor.Command(query, page));
}