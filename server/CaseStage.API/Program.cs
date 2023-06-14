using CaseStage.API.Context;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//SQL Server
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger Documentation
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CaseStage API",
        Description = "CaseStage API is a .NET backend application for proccess controls"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

//Cors
builder.Services.AddCors(options => options.AddPolicy(name: "AreaOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    }));

//Repositories
builder.Services.AddTransient<IApplicationContext, ApplicationContext>();
builder.Services.AddTransient<IAreaRepository, AreaRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddTransient<ISystemAppRepository, SystemAppRepository>();
builder.Services.AddTransient<IProccessRepository, ProccessRepository>();

//Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AreaOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
