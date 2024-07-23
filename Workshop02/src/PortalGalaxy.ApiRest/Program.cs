using Microsoft.EntityFrameworkCore;
using PortalGalaxy.DataAccess;
using PortalGalaxy.Entities;
using PortalGalaxy.Negocio.Implementaciones;
using PortalGalaxy.Negocio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PortalGalaxyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortalGalaxy"));
});

builder.Services.AddTransient<IAlumnoRepository, AlumnoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/Alumnos", (IAlumnoRepository repository) =>
{
    return Results.Ok(repository.List());
});

app.MapPost("api/Alumnos", (IAlumnoRepository repository, Alumno request) =>
{
    repository.Add(request);

    return Results.Ok();
});

app.Run();

