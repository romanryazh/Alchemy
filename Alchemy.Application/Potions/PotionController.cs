using Alchemy.Application.Potions.Commands.CreatePotion;
using Alchemy.Application.Potions.DTOs;
using Alchemy.Application.Potions.Queries.GetPotion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alchemy.Application.Potions;

[ApiController]
[Route("api/potions")]
public class PotionController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePotionCommand command, CancellationToken ct)
    {
        var potionDto = await mediator.Send(command, ct);
        return Ok(potionDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PotionDto>> GetById(Guid id, CancellationToken ct)
    {
        var potionDto = await mediator.Send(new GetPotionByIdQuery(id), ct);
        return Ok(potionDto);
    }
}