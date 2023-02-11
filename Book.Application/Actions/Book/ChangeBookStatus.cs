using Book.Application.DataContext;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Book.Application.Actions.Book;

public static class ChangeBookStatus
{
    public sealed record Command(Guid BookId, bool IsAvailable) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId, cancellationToken);
            book.IsAvailable = request.IsAvailable;
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