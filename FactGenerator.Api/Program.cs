using AutoMapper;
using FactGenerator.Api.Helpers;
using FactGenerator.Core.Mappers.AutoMapper;
using FactGenerator.Repo.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("FactGeneratorConnection");

// Add services to the container.

builder.Services.AddControllers();
// CORS
builder.Services.AddCors();

// AutoMapper
var mappingConfig = new MapperConfiguration(mappingConfig =>
{
    mappingConfig.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(connString);
});

// Register custom middleware
builder.Services.RegisterTypes();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
    .WithOrigins(new[] { "http://localhost:8080" })
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();
