using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Shared.BaseModels.ApiControllerModels;

[ApiController]
public class BaseApiController : Controller
{
    private readonly IMediator _mediator;

    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}