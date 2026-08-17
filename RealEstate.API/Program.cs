using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Application.Interfaces;
using RealEstate.Application.Services;
using RealEstate.Application.Mappings;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));

// Configure AutoMapper
builder.Services.AddAutoMapper(config => {}, typeof(MappingProfile).Assembly);

// Configure DI for Repositories
builder.Services.AddScoped<IAmentiesRepository, AmentiesRepository>();
builder.Services.AddScoped<IPlansRepository, PlansRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// Configure DI for Services
builder.Services.AddScoped<IAmentiesService, AmentiesService>();
builder.Services.AddScoped<IPlansService, PlansService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
