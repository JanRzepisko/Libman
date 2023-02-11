using Book.Application.Actions.Author;
using Book.Application.Actions.Book;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Book.Application.EventConsumers;

public class ChangedBookStatusConsumer : IConsumer<ChangedBookStatusEvent>
{
    private readonly IMediator _mediator;
    public ChangedBookStatusConsumer(IMediator mediator) => _mediator = mediator;

    public Task Consume(ConsumeContext<ChangedBookStatusEvent> context) =>
        _mediator.Send(new ChangeBookStatus.Command(context.Message.BookId, context.Message.IsAvailable));
}