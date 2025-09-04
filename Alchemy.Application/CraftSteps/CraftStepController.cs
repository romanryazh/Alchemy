using Alchemy.Application.CraftSteps.Commands.CreateCraftStep;
using Alchemy.Application.CraftSteps.DTOs;
using Alchemy.Application.CraftSteps.Queries.GetCraftComponent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alchemy.Application.CraftSteps;

[ApiController]
[Route("api/craft-steps")]
public class CraftStepController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCraftStepCommand command, CancellationToken ct)
    {
        var stepId = await mediator.Send(command, ct);
        return Ok(stepId);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CraftStepDto>> GetById(Guid id, CancellationToken ct)
    {
        var stepDto = await mediator.Send(new GetCraftStepByIdQuery(id), ct);
        return Ok(stepDto);
    }
}