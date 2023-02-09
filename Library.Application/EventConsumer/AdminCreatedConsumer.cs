using Library.Application.Actions.Admin;
using Library.Application.Actions.Users;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Library.Application.EventConsumer;

public class AdminCreatedConsumer : IConsumer<AdminCreatedEvent>
{
    private readonly MediatR.IMediator _mediator;
    public AdminCreatedConsumer(IMediator mediator) => _mediator = mediator;


    public Task Consume(ConsumeContext<AdminCreatedEvent> context) =>
        _mediator.Send(new CreateAdmin.Command(context.Message.Id, context.Message.Name, context.Message.LibraryId));
}