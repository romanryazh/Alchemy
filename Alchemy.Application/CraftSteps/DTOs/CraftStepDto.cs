using Alchemy.Application.Components.DTOs;

namespace Alchemy.Application.CraftSteps.DTOs;

public record CraftStepDto(Guid Id, string Name, string Description, int Order, List<ComponentDto> Components);