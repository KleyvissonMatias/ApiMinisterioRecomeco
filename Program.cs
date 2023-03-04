using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Constants;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using ApiMinisterioRecomeco.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "API Minist�rio Recome�o",
            Description = "API de cadastro de novos membros volunt�rios do minist�rio recome�o da igreja do amor.",
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
                         .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
    IConfiguration _configuration = builder.Build();

    var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

    var connectionString = _configuration.GetConnectionString(Constants.CONNECTION_STRING);
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddScoped<IService<Celula>, CelulaService>();
builder.Services.AddScoped<IService<Voluntario>, VoluntarioService>();
builder.Services.AddScoped<IService<Vida>, VidaService>();
builder.Services.AddScoped<IService<Relatorio>, RelatorioService>();

builder.Services.AddScoped<ICelulaRepository, CelulaRepositoryImpl>();
builder.Services.AddScoped<IVidaRepository, VidaRepositoryImpl>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepositoryImpl>();
builder.Services.AddScoped<IVoluntarioRepository, VoluntarioRepositoryImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Minist�rio Recome�o v1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
