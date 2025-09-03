using Alchemy.Application.Components.DTOs;
using MediatR;

namespace Alchemy.Application.Components.Queries.GetComponent;

public record GetComponentByIdQuery(Guid Id) : IRequest<ComponentDto>;