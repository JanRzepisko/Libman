using FluentValidation;
using Library.Application.DataAccess;
using Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;

namespace Library.Application.Actions.Users;

public static class ReturnBook
{
    public sealed record Command(Guid RentalId) : IRequest<Unit>;

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
            var rental = await _unitOfWork.Rentals.GetByIdAsync(request.RentalId, cancellationToken);
            if (rental is null)
            {
                throw new EntityNotFound<Rental>();
            }

            await _unitOfWork.RentalsHistory.AddAsync(new RentalHistory
            {
                UserId = rental.UserId,
                BookId = rental.BookId,
                RentalDate = rental.RentalDate,
                ReturnDate = DateTime.Now
            }, cancellationToken);
            
            _unitOfWork.Rentals.Remove(rental);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _eventBus.PublishAsync(new ChangedBookStatus()
            {
                IsAvailable = true,
                BookId = rental.BookId
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