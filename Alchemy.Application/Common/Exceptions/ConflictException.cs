namespace Alchemy.Application.Common.Exceptions;

public class ConflictException(string message): DomainException(message)
{
    public static void Throw(string message) => throw new ConflictException(message);
}