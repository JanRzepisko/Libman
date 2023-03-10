using Identity.Application.Actions.Command.Admin;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Identity.Application.EventConsumer;

public sealed class AdminSetLibraryConsumer : IConsumer<AdminSetLibraryEvent>
{
    private readonly IMediator _mediator;
    public AdminSetLibraryConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Consume(ConsumeContext<AdminSetLibraryEvent> context)
    {
        _mediator.Send(new UpdateAdmin.Command(context.Message.LibraryId), default);
        Console.WriteLine("Working");
    }
}