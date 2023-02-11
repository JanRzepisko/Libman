using FluentValidation;
using Library.Application.DataAccess;
using Library.Application.DTO;
using Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.BaseModels.Exceptions;
using Shared.Service.Interfaces;
using TaskExtensions = System.Data.Entity.SqlServer.Utilities.TaskExtensions;

namespace Eparafia.Application.Actions.Parish;

public static class GetUsers
{
    public sealed record Command(int page) : IRequest<List<UserDTO>>;

    public class Handler : IRequestHandler<Command, List<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<List<UserDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(_userProvider.Id, cancellationToken);
            if (admin == null)
            {
                throw new EntityNotFound<Admin>();
            }

            var result = await _unitOfWork.Users.GetUsersByLibrary(admin.LibraryId, request.page,cancellationToken);
            return result.Select(UserDTO.FromEntity).ToList();
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}