namespace Alchemy.Application.Common.Exceptions;

public record ValidationError(string PropertyName, string Message);