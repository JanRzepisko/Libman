using Library.Application.Actions.Book;
using MassTransit;
using MediatR;
using Shared.Messages;

namespace Library.Application.EventConsumer;

public class RemovedBookConsumer : IConsumer<BookRemovedEvent>
{
    private readonly IMediator _mediator;
    public RemovedBookConsumer(IMediator mediator) => _mediator = mediator;
    
    public Task Consume(ConsumeContext<BookRemovedEvent> context) => 
        _mediator.Send(new RemoveBook.Command(context.Message.Id));
}