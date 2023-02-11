using FluentValidation;
using Library.Application.DataAccess;
using Library.Application.DTO;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.Service.Interfaces;

namespace Library.Application.Actions.Library;

public static class GetRentalHistory
{
    public sealed record Command(int Page) : IRequest<List<RentalHistoryDTO>>;

    public class Handler : IRequestHandler<Command, List<RentalHistoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<List<RentalHistoryDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            Domain.Entities.Admin? admin = await _unitOfWork.Admins.GetByIdAsync(_userProvider.Id ,cancellationToken);
            
            var result = await _unitOfWork.RentalsHistory.GetByLibrary(admin.LibraryId, request.Page, cancellationToken);
            return result.Select(RentalHistoryDTO.FromEntity).ToList();
        }
    }
}