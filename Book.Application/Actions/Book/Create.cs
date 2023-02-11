using Book.Application.DataContext;
using Book.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;

namespace Book.Application.Actions.Book;

public static class CreateBook
{
    public sealed record Command(string Title, Guid AuthorId, Guid LibraryId, int ReleaseYear) : IRequest<Unit>;

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
            var author = await _unitOfWork.Authors.GetByIdAsync(request.AuthorId, cancellationToken);
            if (author is null) 
                throw new EntityNotFound<Domain.Entities.Author>();

            Guid bookId = Guid.NewGuid();
            await _unitOfWork.Books.AddAsync(new Domain.Entities.Book()
            {
                AuthorId = request.AuthorId,
                LibraryId = request.LibraryId,
                ReleaseYear = request.ReleaseYear,
                Title = request.Title,
                Id = bookId,
                IsAvailable = true
            }, cancellationToken); 
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _eventBus.PublishAsync(new BookCreatedEvent()
            {
                Id = bookId,
                Title = request.Title,
                LibraryId = request.LibraryId,
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