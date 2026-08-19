using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Data;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Application.Interfaces;
using RealEstate.Application.Services;
using RealEstate.Application.Mappings;
using System.Text.Json.Serialization;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

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

// Configure DynamoDB
var awsOptions = builder.Configuration.GetAWSOptions();
var accessKey = builder.Configuration["AWS:AccessKey"];
var secretKey = builder.Configuration["AWS:SecretKey"];
if (!string.IsNullOrEmpty(accessKey) && !string.IsNullOrEmpty(secretKey))
{
    awsOptions.Credentials = new Amazon.Runtime.BasicAWSCredentials(accessKey, secretKey);
}
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddAWSService<Amazon.S3.IAmazonS3>();
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
builder.Services.AddSingleton<IDynamoDbIdGenerator, DynamoDbIdGenerator>();

// Configure AutoMapper
builder.Services.AddAutoMapper(config => {}, typeof(MappingProfile).Assembly);

// Configure DI for Repositories
builder.Services.AddScoped<IAmentiesRepository, AmentiesRepository>();
builder.Services.AddScoped<IPlansRepository, PlansRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();

// Configure DI for Services
builder.Services.AddScoped<IAmentiesService, AmentiesService>();
builder.Services.AddScoped<IPlansService, PlansService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<RealEstate.Application.Interfaces.IService<RealEstate.Domain.Entities.Feature, RealEstate.Application.DTOs.FeatureDto, RealEstate.Application.DTOs.CreateFeatureDto, RealEstate.Application.DTOs.UpdateFeatureDto>, RealEstate.Application.Services.FeatureService>();
builder.Services.AddScoped<IS3Service, RealEstate.Infrastructure.Services.S3Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
