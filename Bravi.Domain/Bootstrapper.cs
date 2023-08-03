using Microsoft.Extensions.DependencyInjection;

namespace Bravi.Domain;

public static class Bootstrapper
{
    public static void ConfigureDomain(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
    }
}