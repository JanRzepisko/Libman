using FluentValidation;
using Library.Application.DataAccess;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;

namespace Library.Application.Actions.Library;

public static class GetById
{
    public sealed record Query(Guid Id) : IRequest<Domain.Entities.Library>;

    public class Handler : IRequestHandler<Query, Domain.Entities.Library>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.Library> Handle(Query request, CancellationToken cancellationToken)
        {
            var library = await _unitOfWork.Libraries.GetByIdAsync(request.Id, cancellationToken);
            if(library is null)
            {
                throw new EntityNotFound<Domain.Entities.Library>();
            }

            return library;
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {

            }
        }
    }
}