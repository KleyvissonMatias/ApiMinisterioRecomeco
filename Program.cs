using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Constants;
using ApiMinisterioRecomeco.Controllers;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using ApiMinisterioRecomeco.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "API Ministério Recomeço",
            Description = "API de cadastro de novos membros voluntários do ministério recomeço da igreja do amor.",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Kleyvisson Matias",
                Url = new Uri("https://github.com/KleyvissonMatias"),
                Email = "kleyvissonmatias@gmail.com"
            }
        });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    IConfiguration _configuration = builder.Build();

    var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

    var connectionString = _configuration.GetConnectionString(Constants.CONNECTION_STRING);
    options.UseMySql(connectionString, serverVersion,
        providerOptions => providerOptions.EnableRetryOnFailure(maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null));
});

builder.Services.AddScoped<CelulaController, CelulaController>();
builder.Services.AddScoped<VoluntarioController, VoluntarioController>();
builder.Services.AddScoped<VidaController, VidaController>();
builder.Services.AddScoped<RelatorioController, RelatorioController>();


builder.Services.AddScoped<CelulaService, CelulaService>(service => new(celulaRepository: service.GetRequiredService<CelulaRepository>(), logger: service.GetRequiredService<ILogger<Celula>>()));
builder.Services.AddScoped<VoluntarioService, VoluntarioService>(service => new(voluntarioRepository: service.GetRequiredService<VoluntarioRepository>(), logger: service.GetRequiredService<ILogger<Voluntario>>()));
builder.Services.AddScoped<VidaService, VidaService>(service => new(vidaRepository: service.GetRequiredService<VidaRepository>(), logger: service.GetRequiredService<ILogger<Vida>>()));
builder.Services.AddScoped<RelatorioService, RelatorioService>(service => new(relatorioRepository: service.GetRequiredService<RelatorioRepository>(), logger: service.GetRequiredService<ILogger<Relatorio>>()));

builder.Services.AddScoped<CelulaRepository, CelulaRepositoryImpl>();
builder.Services.AddScoped<VidaRepository, VidaRepositoryImpl>();
builder.Services.AddScoped<RelatorioRepository, RelatorioRepositoryImpl>();
builder.Services.AddScoped<VoluntarioRepository, VoluntarioRepositoryImpl>();

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Migrando banco de dados...");
        var db = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();

        //serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
        logger.LogInformation("Banco de dados migrado com sucesso.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ocorreu um erro enquanto migrava o banco de dados.");
    }
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ministério Recomeço v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
