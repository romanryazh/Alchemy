using MediatR;

namespace Alchemy.Application.Locations.Commands.CreateLocation;

public record CreateLocationCommand : IRequest<Guid>
{
    /// <summary>
    /// Название
    /// </summary>
    /// <example>Придорожный Лес</example>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание 
    /// </summary>
    /// <example>Пара деревьев у трассы по дороге на дачу</example>
    public string Description { get; init; }

    public CreateLocationCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
}