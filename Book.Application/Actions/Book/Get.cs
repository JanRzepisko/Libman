using Book.Application.DataContext;
using Book.Application.DTO;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.Service.Interfaces;

namespace Book.Application.Actions.Book;

public static class GetBook
{
    public sealed record Command(string SearchString, int page, Guid LibraryId) : IRequest<List<BookDTO>>;

    public class Handler : IRequestHandler<Command, List<BookDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BookDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await  _unitOfWork.Books.Search(request.SearchString, request.page, request.LibraryId, cancellationToken);
            return result.Select(BookDTO.FromEntity).ToList();
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}