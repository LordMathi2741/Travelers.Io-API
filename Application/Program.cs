using System.Reflection;
using Application.Mapper;
using Domain.Interfaces;
using Domain.Repository;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Travelers.Io API",
            Description = "Travelers.Io API documentation",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Example Contact",
                Url = new Uri("https://example.com/contact")
            },
            License = new OpenApiLicense
            {
                Name = "Example License",
                Url = new Uri("https://example.com/license")
            }
        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddAutoMapper(typeof(ModelToRequest), typeof(ModelToResponse), typeof(RequestToModel));

var connectionString = builder.Configuration.GetConnectionString("TravelersIoDB");

builder.Services.AddDbContext<TravelersDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, 
            ServerVersion.AutoDetect(connectionString) 
        );
    });

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TravelersDbContext>();
    context.Database.EnsureCreated();
}

//EF
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<TravelersDbContext>())
{
    context.Database.EnsureCreated();
}

app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();