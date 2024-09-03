using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectonString = configuration.GetConnectionString("MyDB");
        services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectonString));
        return services;
    }

}
