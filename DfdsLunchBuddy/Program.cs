using DfdsLunchBuddy;
using DfdsLunchBuddy.Application;
using DfdsLunchBuddy.Extensions;
using DfdsLunchBuddy.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .SetupSwaggerDocumentation()
        .SetupApiVersioning(); 
}

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
{
    app.UseExceptionHandler("/error"); 
    
    if (app.Environment.IsDevelopment())
    {

        app.UseSwaggerDocumentation(provider, "localhost:7282");
    }
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}