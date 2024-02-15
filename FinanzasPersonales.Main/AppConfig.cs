using FinanzasPersonales.Application.Contracts.Repositories.Reader;
using FinanzasPersonales.Application.Contracts.Repositories.Writer;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using FinanzasPersonales.Persistence.Repositories.Writers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public static class AppConfig
{
    public static void Configure(HostBuilderContext hostContext, IServiceCollection services)
    {
        // Configuración de la cadena de conexión desde appsettings.json
        IConfiguration configuration = hostContext.Configuration;
        services.AddDbContext<EfDatabeseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

        services.AddLogging();
        services.AddScoped<CategoryWriteRepository<Category>, CategoryWriteRepository>();
    }

    public static void ApplyMigrations(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<EfDatabeseContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<object>>();
            try
            {
                // Aplica las migraciones pendientes
                dbContext.Database.Migrate();
                Console.WriteLine("Migraciones aplicadas correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
            }
        }
    }
}
