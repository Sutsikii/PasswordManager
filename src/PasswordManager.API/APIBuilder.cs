using PasswordManager.Database;
using PasswordManager.Repository;

namespace PasswordManager.API;

public static class APIBuilder
{
    public static void AddPasswordManagerContext(this IServiceCollection services)
    {
        services.AddScoped<PasswordManagerContext>(i => new PasswordManagerContext(i.GetRequiredService<IConfiguration>()).MigrateAndGet());
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        Type[] types = typeof(ARepository).Assembly.GetTypes()
            .Where(i => !i.IsAbstract && i.IsAssignableTo(typeof(ARepository)))
            .ToArray();

        foreach (Type type in types)
        {
            services.AddScoped(type);
        }
    }
}
