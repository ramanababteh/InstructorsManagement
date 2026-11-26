using API.Pipeline;
using API.Services;
using API.ServicesInterfaces;
using DbReposirory;
using DbReposirory.Interfaces;
using DbReposirory.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IInstructorService, InstructorService>();

builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware <ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
