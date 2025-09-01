using Alchemy.Application.Common.Exceptions;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.Locations.Commands.CreateLocation;

public class CreateLocationCommandHandler(ILocationRepository locationRepository, IUniqueCheckerService checker)
    : IRequestHandler<CreateLocationCommand, Guid>
{
    public async Task<Guid> Handle(CreateLocationCommand request, CancellationToken ct)
    {
        if (!await checker.IsUniqueAsync<Location>("Name", request.Name, ct))
        {
            ConflictException.Throw($"Локация с названием {request.Name} уже существует");
        }
        
        var location = Location.Create(request.Name, request.Description);
       
        await locationRepository.AddAsync(location, ct);
        return location.Id.Value;
    }
}