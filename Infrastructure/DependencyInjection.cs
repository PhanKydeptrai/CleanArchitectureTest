using Domain.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Đăng ký EmployeeRepository
        services.AddScoped<IEmployeeRepository ,EmployeeRepository>();
        // Đăng ký UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
