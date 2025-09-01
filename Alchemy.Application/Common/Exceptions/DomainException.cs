namespace Alchemy.Application.Common.Exceptions;

public class DomainException(string message) : Exception(message)
{
    public static void Throw(string message) => throw new DomainException(message);
}