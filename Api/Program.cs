using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using TodoApi.Data;
using TodoApi.Data.Repositories;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//builder.Services.AddDbContext<PosgreSQLConfig>(opt =>
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton(builder.Services.AddDbContext<PosgreSQLConfig>(options =>
    options.UseSqlServer("WebApiDatabase")));

builder.Services.AddScoped<localizacionRepository>();
builder.Services.AddScoped<jugadorRepository>();
builder.Services.AddScoped<rankingRepository>();
builder.Services.AddScoped<nivelRepository>();
builder.Services.AddScoped<elementoRepository>();
builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAllOrigins"); // Agrega los encabezados CORS

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();