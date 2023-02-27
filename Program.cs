using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Constants;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Repository;
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
    options.UseMySql(Constants.CONNECTION_STRING, ServerVersion.AutoDetect(Constants.CONNECTION_STRING));
});

builder.Services.AddScoped<ICelulaRepository, CelulaRepositoryImpl>();
builder.Services.AddScoped<IVidaRepository, VidaRepositoryImpl>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepositoryImpl>();
builder.Services.AddScoped<IVoluntarioRepository, VoluntarioRepositoryImpl>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ministério Recomeço v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
