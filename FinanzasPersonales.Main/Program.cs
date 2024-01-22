using FinanzasPersonales.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args);

// Configuración de la cadena de conexión desde appsettings.json
builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.SetBasePath(Directory.GetCurrentDirectory());
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
});

// Configuración del DbContextOptions con la cadena de conexión
builder.ConfigureServices((hostContext, services) =>
{
    services.AddDbContext<EfDatabeseContext>(options =>
        options.UseSqlServer(hostContext.Configuration.GetConnectionString("ConnectionString")));
});

var app = builder.Build();

// Crea una instancia del DbContext para aplicar las migraciones
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EfDatabeseContext>();
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

app.Run();
