using Library.Application.Actions.Users;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Library.Application.EventConsumer;

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly MediatR.IMediator _mediator;
    public UserCreatedConsumer(IMediator mediator) => _mediator = mediator;

    public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
        _mediator.Send(new CreateUser.Command(context.Message.Id, context.Message.Name, context.Message.LibraryId));
}