namespace Alchemy.Application.Common.Exceptions;

public class NotFoundException(string message) : DomainException(message)
{
    public static void Throw(string entityName, Guid id) =>
        throw new NotFoundException($"Сущность {entityName} с ID {id} не найдено.");
}