using Alchemy.Application.Common;
using Alchemy.Application.Effects.Commands.CreateEffect;
using Alchemy.Application.Effects.Commands.DeleteEffect;
using Alchemy.Application.Effects.Commands.UpdateEffect;
using Alchemy.Application.Effects.DTOs;
using Alchemy.Application.Effects.Queries.GetEffect;
using Alchemy.Application.Effects.Queries.GetEffectList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alchemy.Application.Effects;

[ApiController]
[Route("api/effects")]
public class EffectController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EffectDto>> GetById(Guid id, CancellationToken ct)
    {
        var effectDto = await mediator.Send(new GetEffectByIdQuery(id), ct);
        return Ok(effectDto);
    }


    /// <summary>
    /// Создать новый эффект
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST
    ///     {
    ///         "name" : "Лечение",
    ///         "description" : "Лечит"
    ///     }
    /// 
    /// </remarks>
    /// <param name="command">Данные запроса</param>
    /// <param name="ct">Токен отмены <see cref="CancellationToken"/></param>
    /// <returns>Id созданного эффекта</returns>
    /// <response code="200">Успешное создание</response>
    /// <response code="400">Ошибка валидации</response>
    /// <response code="409">Конфликт</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateEffectCommand), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateEffectCommand command, CancellationToken ct)
    {
        var effectId = await mediator.Send(command, ct);
        return Ok(effectId);
    }

    [HttpDelete("{id:guid}")]
    
    public async Task<ActionResult> Delete(Guid id, CancellationToken ct)
    {
        await mediator.Send(new DeleteEffectCommand(id), ct);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, string name, string description, CancellationToken ct)
    {
        await mediator.Send(new UpdateEffectCommand(id, name, description), ct);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<EffectDto>>> GetAll([FromQuery] GetEffectListQuery query,
        CancellationToken ct)
    {
        var queryResult = await mediator.Send(query, ct); 
        return Ok(queryResult);
    }
}