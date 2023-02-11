using System.Data.Entity.Infrastructure;
using Book.Application.DataContext;
using Book.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;

namespace Book.Application.Actions.Book;

public static class RemoveBook
{
    public sealed record Command(Guid BookId) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if(!await _unitOfWork.Books.ExistsAsync(request.BookId, cancellationToken))
                throw new EntityNotFound<Domain.Entities.Book>();
            
            _unitOfWork.Books.RemoveById(request.BookId);
            _unitOfWork.SaveChangesAsync(cancellationToken);
            
            await _eventBus.PublishAsync(new BookRemovedEvent()
            {
                Id = request.BookId,
            }, cancellationToken);
            
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}