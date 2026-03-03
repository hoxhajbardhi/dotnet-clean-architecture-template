using DotNetCleanArchitectureTemplate.Infrastructure;
using DotNetCleanArchitectureTemplate.WebApi.Endpoints;
using DotNetCleanArchitectureTemplate.WebApi.Middleware;


var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// endpoints
app.MapWorkItems();

app.Run();
