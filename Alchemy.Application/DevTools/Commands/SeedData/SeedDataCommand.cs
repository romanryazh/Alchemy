using MediatR;

namespace Alchemy.Application.DevTools.Commands.SeedData;

public record SeedDataCommand : IRequest<SeedDataResultDto>;