using Library.Application.Actions.Book;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Library.Application.EventConsumer;

public class CreatedBookConsumer : IConsumer<BookCreatedEvent>
{
    private readonly MediatR.IMediator _mediator;
    public CreatedBookConsumer(IMediator mediator) => _mediator = mediator;
    
    public Task Consume(ConsumeContext<BookCreatedEvent> context) => 
        _mediator.Send(new CreateBook.Command(context.Message.Id, context.Message.Title, context.Message.LibraryId));
}