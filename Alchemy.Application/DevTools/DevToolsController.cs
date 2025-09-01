using Alchemy.Application.DevTools.Commands.SeedData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alchemy.Application.DevTools;

[ApiController]
[Route("api/dev-tools")]
public class DevToolsController(IMediator mediator) : ControllerBase
{
    [HttpPost("seed-data")]
    public async Task<ActionResult<SeedDataResultDto>> SeedTestData(CancellationToken ct)
    {
        var result = await mediator.Send(new SeedDataCommand(), ct);
        return Ok(result);
    }
}