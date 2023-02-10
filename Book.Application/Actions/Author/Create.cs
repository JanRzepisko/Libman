using Book.Application.DataContext;
using Book.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.EventBus;
using Shared.Messages;

namespace Book.Application.Actions.Author;

public static class CreateAuthor
{
    public sealed record Command(string Firstname, string Surname) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken = default)
        {
            if (await _unitOfWork.Authors.ExistNameAsync(request.Firstname, request.Surname, cancellationToken)) 
                throw new EntityExist<Domain.Entities.Author>();

            await _unitOfWork.Authors.AddAsync(new Domain.Entities.Author()
            {
                Firstname = request.Firstname,
                Surname = request.Surname
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