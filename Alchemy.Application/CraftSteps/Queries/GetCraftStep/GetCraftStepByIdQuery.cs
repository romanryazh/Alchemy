using Alchemy.Application.CraftSteps.DTOs;
using MediatR;

namespace Alchemy.Application.CraftSteps.Queries.GetCraftComponent;

public record GetCraftStepByIdQuery(Guid Id) : IRequest<CraftStepDto>;