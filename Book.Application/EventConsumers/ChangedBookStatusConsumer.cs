using Book.Application.Actions.Author;
using Book.Application.Actions.Book;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Book.Application.EventConsumers;

public class ChangedBookStatusConsumer : IConsumer<ChangedBookStatusEvent>
{
    private readonly Mediator _mediator;

    public ChangedBookStatusConsumer(Mediator mediator)
    {
        _mediator = mediator;
    }

    public Task Consume(ConsumeContext<ChangedBookStatusEvent> context)
    {
        return _mediator.Send(new ChangeBookStatus.Command(context.Message.BookId, context.Message.IsAvailable));
    }
}