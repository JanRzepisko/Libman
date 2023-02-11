using Library.Application.Actions.Book;
using Library.Application.Actions.Library;
using Library.Application.Actions.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;

namespace Library.API.Controllers;

[ApiController]
[Authorize("Admin")]
[Route("Rental")]
public class RentalController : BaseApiController
{
    public RentalController(IMediator mediator) : base(mediator){}
    
    [HttpPost("RentBook")]
    public Task<IActionResult> Endpoint(RentBook.Command request) => base.Endpoint(request);    
    
    [HttpPost("ReturnBook")]
    public Task<IActionResult> Endpoint(ReturnBook.Command request) => base.Endpoint(request);
    
    [HttpGet]
    public Task<IActionResult> Endpoint(Guid UserId, int page) => base.Endpoint(new GetRentals.Command(UserId, page));
    
    [HttpGet("History")]
    public Task<IActionResult> Endpoint(int page) => base.Endpoint(new GetRentalHistory.Command(page));
}