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

public static class UpdateAuthor
{
    public sealed record Command(Guid AuthorId, string? Firstname, Guid? Surname) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(request.AuthorId, cancellationToken);
            if (author is null)
            {
                throw new EntityNotFound<Domain.Entities.Book>();
            }
            
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