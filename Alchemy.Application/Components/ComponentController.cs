using Alchemy.Application.Components.Commands.CreateComponent;
using Alchemy.Application.Components.DTOs;
using Alchemy.Application.Components.Queries.GetComponent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alchemy.Application.Components;

[ApiController]
[Route("api/components")]
public class ComponentController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Создать новый компонент
    /// </summary>
    /// <param name="command">Данные запроса</param>
    /// <param name="ct">Токен отмены <see cref="CancellationToken"/></param>
    /// <returns>Уникальный идентификатор</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateComponentCommand command, CancellationToken ct)
    {
        var id = await mediator.Send(command, ct);
        return Ok(id);
    }

    /// <summary>
    /// Получить компонент по Id 
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <param name="ct">Токен отмены <see cref="CancellationToken"/></param>
    /// <returns>Данные о компоненте <see cref="ComponentDto"/></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ComponentDto>> GetById(Guid id, CancellationToken ct)
    {
        var componentDto = await mediator.Send(new GetComponentByIdQuery(id), ct);
        return Ok(componentDto);
    }
}