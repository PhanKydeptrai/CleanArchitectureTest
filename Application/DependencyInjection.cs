using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        //Đăng ký dependency injection cho FluentValidation
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services;
    }
    
}
