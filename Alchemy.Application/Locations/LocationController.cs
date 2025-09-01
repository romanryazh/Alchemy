using Alchemy.Application.Locations.Commands.CreateLocation;
using Alchemy.Application.Locations.DTOs;
using Alchemy.Application.Locations.Queries.GetLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alchemy.Application.Locations;

[ApiController]
[Route("api/Locations")]
public class LocationController(IMediator mediator) : ControllerBase
{
    
    /// <summary>
    /// Создать новую локацию
    /// </summary>
    /// <param name="command">Данные запроса</param>
    /// <param name="ct">Токен отмены <see cref="CancellationToken"/></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateLocationCommand command, CancellationToken ct)
    {
        var locationId = await mediator.Send(command, ct);
        return Ok(locationId);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LocationDto>> GetById(Guid id, CancellationToken ct)
    {
        var locationDto = await mediator.Send(new GetLocationByIdQuery(id), ct);
        return Ok(locationDto);
    }
}