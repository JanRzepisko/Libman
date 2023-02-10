using FluentValidation;
using Library.Application.DataAccess;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Actions.Book;

public static class CreateBook
{
    public sealed record Command(Guid BookId, string Title, Guid LibraryId) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Books.AddAsync(new Domain.Entities.Book
            {
                Id = request.BookId,
                Title = request.Title,
                LibraryId = request.LibraryId,
                IsAvailable = true,
                RentalId = null
            }, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
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