using Alchemy.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace Alchemy.WebApi.Middlewares;

public class ExceptionHandlingMiddleware : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken ct)
    {
        var (statusCode, title, detail, errors) = exception switch
        {
            ValidationException validationException => (
                StatusCodes.Status400BadRequest,
                "Ошибка валидации",
                "Произошла одна или несколько ошибок валидации",
                validationException.Errors),

            NotFoundException => (
                StatusCodes.Status404NotFound,
                "Не найдено",
                exception.Message,
                null),

            ConflictException => (
                StatusCodes.Status409Conflict,
                "Конфликт",
                exception.Message,
                null),

            ArgumentException => (
                StatusCodes.Status400BadRequest,
                "Ошибка аргумента",
                exception.Message,
                null),

            DomainException => (
                StatusCodes.Status400BadRequest,
                "Нарушение бизнес правил",
                exception.Message,
                null),

            _ => (
                StatusCodes.Status500InternalServerError,
                "Внутренняя ошибка сервера",
                "Произошла непредвиденная ошибка",
                null),
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(new
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Errors = errors
        }, ct);

        return true;
    }
}