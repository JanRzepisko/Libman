using Book.Application.DataContext;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Book.Application.Actions.Author;

public static class SearchAuthor
{
    public sealed record Command(string Query, int Page) : IRequest<List<Domain.Entities.Author>>;

    public class Handler : IRequestHandler<Command, List<Domain.Entities.Author>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Domain.Entities.Author>> Handle(Command request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Authors.Search(request.Query, request.Page, cancellationToken);
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}