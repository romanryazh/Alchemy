using Alchemy.Application.Common.Exceptions;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.Locations.Commands.CreateLocation;

public class CreateLocationCommandHandler(IUnitOfWork unitOfWork, IUniqueCheckerService checker)
    : IRequestHandler<CreateLocationCommand, Guid>
{
    public async Task<Guid> Handle(CreateLocationCommand request, CancellationToken ct)
    {
        if (request.Name == string.Empty)
        {
            throw new ArgumentException("Имя не может быть пустым");
        }
        
        if (!await checker.IsUniqueAsync<Location>("Name", request.Name, ct))
        {
            ConflictException.Throw($"Локация с названием {request.Name} уже существует");
        }
        
        var location = Location.Create(request.Name, request.Description);
        await unitOfWork.LocationRepository.AddAsync(location, ct);
        
        await unitOfWork.SaveChangesAsync(ct);
        
        return location.Id.Value;
    }
}