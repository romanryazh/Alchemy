using Alchemy.Application.Common;
using Alchemy.Application.Effects.DTOs;
using MediatR;

namespace Alchemy.Application.Effects.Queries.GetEffectList;

/// <summary>
/// 
/// </summary>
/// <param name="PageIndex">Номер страницы (по умолчанию: 1)</param>
/// <param name="PageSize">Количество элементов на странице (по умолчанию: 5)</param>
public record GetEffectListQuery(int PageIndex, int PageSize) : IRequest<PaginatedList<EffectDto>>;