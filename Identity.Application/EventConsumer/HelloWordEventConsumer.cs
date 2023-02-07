using Identity.Application.Actions.Query.User;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Identity.Application.EventConsumer;

public sealed class HelloWordEventConsumer : IConsumer<HelloWord>
{
    private readonly IMediator _mediator;
    public HelloWordEventConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Consume(ConsumeContext<HelloWord> context)
    {
        _mediator.Send(new LoginUser.Command("string", "string"), default);
        Console.WriteLine("Working");
    }
}