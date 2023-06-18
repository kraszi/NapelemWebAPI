using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using WebUj.Interfaces;
using WebUj.Models;
using WebUj.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ComponentInterface, ComponentRepository>();
builder.Services.AddScoped<EmployeeInterface, EmployeeRepository>();
builder.Services.AddScoped<ProgressInterface, ProgressRepository>();
builder.Services.AddScoped<ProjectInterface, ProjectRepository>();
builder.Services.AddScoped<StorageInterface, StorageRepository>();
builder.Services.AddScoped<ComponentsToProjectInterface, ComponentsToProjectsRepository>();

builder.Services.AddDbContext<APIDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
);

var app = builder.Build();

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

// 2023.06.01. állapot