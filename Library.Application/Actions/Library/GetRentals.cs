using FluentValidation;
using Library.Application.DataAccess;
using Library.Application.DTO;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace Library.Application.Actions.Library;

public static class GetRentals
{
    public sealed record Command(Guid UserId, int page) : IRequest<List<RentalDTO>>;

    public class Handler : IRequestHandler<Command, List<RentalDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RentalDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Rentals.GetByUser(request.UserId, request.page, cancellationToken);
            return result.Select(RentalDTO.FromEntity).ToList();
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}