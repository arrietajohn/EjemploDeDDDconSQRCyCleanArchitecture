using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    AppConfig.Configure(hostContext, services);
});

var app = builder.Build();

AppConfig.ApplyMigrations(app.Services);

