using Library.Application.Actions.Book;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Library.Application.EventConsumer;

public class RemovedBookConsumer : IConsumer<BookUpdatedEvent>
{
    private readonly Mediator _mediator;

    public RemovedBookConsumer(Mediator mediator)
    {
        _mediator = mediator;
    }

    public Task Consume(ConsumeContext<BookUpdatedEvent> context)
    {
        return _mediator.Send(new RemoveBook.Command(context.Message.Id));
    }
}