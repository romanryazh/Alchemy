using Alchemy.Application.Common;
using Alchemy.Application.Effects.DTOs;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.Effects.Queries.GetEffectList;

public class GetEffectListQueryHandler(IEffectRepository effectRepository)
    : IRequestHandler<GetEffectListQuery, PaginatedList<EffectDto>>
{
    public async Task<PaginatedList<EffectDto>> Handle(GetEffectListQuery request, CancellationToken ct)
    {
        var queryable = effectRepository.GetAll();

        queryable = queryable.OrderBy(x => x.Name);
        
        var effects = await PaginatedList<Effect>
            .PaginateAsync(queryable, request.PageIndex, request.PageSize, ct);
        
        var mappedEffects = effects.Map(e =>
            new EffectDto(e.Id.Value, e.Name, e.Description));

        return mappedEffects;
    }
}