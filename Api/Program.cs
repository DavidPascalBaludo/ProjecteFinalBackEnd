using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using TodoApi.Data;
using TodoApi.Data.Repositories;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<PosgreSQLConfig>(opt =>
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSingleton(builder.Services.AddDbContext<PosgreSQLConfig>(options =>
    options.UseSqlServer("WebApiDatabase")));

builder.Services.AddScoped<localizacionRepository>();
builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();