using FluentValidation;
using Library.Application.DataAccess;
using Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;

namespace Library.Application.Actions.Users;

public static class RentBook
{
    public sealed record Command(Guid UserId, Guid BookId) : IRequest<Unit>;

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
            if (!await _unitOfWork.Users.ExistsAsync(request.UserId, cancellationToken))
                throw new EntityNotFound<User>();

            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId, cancellationToken);
            if (book is null)
            {
                throw new EntityNotFound<Domain.Entities.Book>();
            }

            if (!book.IsAvailable)
            {
                throw new InvalidRequestException("Book is not available");
            }
            
            _unitOfWork.Rentals.AddAsync(new Rental()
            {
                BookId = request.BookId,
                UserId = request.UserId,
                RentalDate = DateTime.Now,
                LibraryId = book.LibraryId
            }, cancellationToken);

            book.IsAvailable = false;
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _eventBus.PublishAsync(new ChangedBookStatusEvent()
            {
                IsAvailable = false,
                BookId = request.BookId
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