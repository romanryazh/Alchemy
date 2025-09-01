using System.Reflection;
using Alchemy.Application;
using Alchemy.Application.Common.Extensions;
using Alchemy.Infrastructure;
using Alchemy.Infrastructure.Extensions;
using Alchemy.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(ConfigureSwagger);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

void ConfigureSwagger(SwaggerGenOptions options)
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Alchemy API", 
        Version = "v1"
    });

    var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
    options.IncludeXmlComments(apiXmlPath);
    
    var applicationXmlFile = $"{ApplicationAssemblyReference.Assembly.GetName().Name}.xml";
    var applicationXmlPath = Path.Combine(AppContext.BaseDirectory, applicationXmlFile);
    options.IncludeXmlComments(applicationXmlPath);
}