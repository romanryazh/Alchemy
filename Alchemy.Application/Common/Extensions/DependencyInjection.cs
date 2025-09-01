using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Alchemy.Application.Common.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);
        
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(ApplicationAssemblyReference.Assembly);
            options.Lifetime = ServiceLifetime.Scoped;
        });
        
        return services;
    }
}