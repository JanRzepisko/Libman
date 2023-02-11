using FluentValidation;
using Library.Application.DataAccess;
using Library.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared.EventBus;
using Shared.Messages;
using Shared.Service.Interfaces;

namespace Library.Application.Actions.Library;

public static class CreateLibrary
{
    public sealed record Command(string Name, Address Address) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;
        private readonly IEventBus _eventBus;

        public Handler(IUnitOfWork unitOfWork, IConfiguration configuration, IEventBus eventBus, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            var creator = await _unitOfWork.Admins.GetByIdAsync(_userProvider.Id, cancellationToken);
            creator.LibraryId = id;
            var library = new Domain.Entities.Library
            {
                Id = id,
                Name = request.Name,
                Address = request.Address,
                Admins = new List<Domain.Entities.Admin>() { creator }
            };
            await _unitOfWork.Libraries.AddAsync(library, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _eventBus.PublishAsync(new AdminSetLibraryEvent(){LibraryId = id}, cancellationToken);
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