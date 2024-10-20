using Microsoft.Extensions.DependencyInjection;

namespace Rms.BLL.Abstraction;

public static class DependencyResolverService
{
    public static IServiceCollection ApplicationRegister(this IServiceCollection services)
    {

        services.AddAutoMapper(typeof(ConfigureAutoMapper).Assembly);

        return services;
    }
}