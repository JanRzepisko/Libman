using Library.Application.Actions.Book;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Library.Application.EventConsumer;

public class UpdatedBookConsumer : IConsumer<BookUpdatedEvent>
{
    private readonly IMediator _mediator;
    public UpdatedBookConsumer(IMediator mediator) => _mediator = mediator;
    
    public Task Consume(ConsumeContext<BookUpdatedEvent> context) => 
        _mediator.Send(new UpdateBook.Command(context.Message.Id, context.Message.Title));
}