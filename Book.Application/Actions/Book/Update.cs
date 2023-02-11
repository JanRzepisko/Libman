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

public static class UpdateBook
{
    public sealed record Command(Guid BookId, string? Title, int? ReleaseYear) : IRequest<Unit>;

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
            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId, cancellationToken);
            if (book is null)
            {
                throw new EntityNotFound<Domain.Entities.Book>();
            }
            
            book.Title = request.Title ?? book.Title;
            book.ReleaseYear = request.ReleaseYear ?? book.ReleaseYear;
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _eventBus.PublishAsync(new BookUpdatedEvent()
            {
                Id = book.Id,
                Title = request.Title,
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